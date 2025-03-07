using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class ItemsForm : Form
    {
        private readonly ItemService _itemService;
        private readonly UnitOfWork _unitOfWork;
        public ItemsForm()
        {
            InitializeComponent();
            _itemService = new ItemService(new UnitOfWork(new WMSDbContext()));
            _unitOfWork = new UnitOfWork(new WMSDbContext());
            LoadItems();
            cmbUnit.Items.AddRange(new string[] { "", "Piece", "Kg", "Liter", "Meter" });
            cmbUnit.SelectedIndex = 0;
        }

        private async Task LoadItems()
        {
            var itemsInWarehouses = await _itemService.GetItemsInWarehousesAsync();
            dgvItems.DataSource = itemsInWarehouses;
            dgvItems.Columns["ItemId"].Visible = false;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToDeleteRows = false;

            var warehouses = await _unitOfWork.Warehouses.GetAllAsync();
            clbWarehouses.DataSource = warehouses;
            clbWarehouses.DisplayMember = "Name";
            clbWarehouses.ValueMember = "Id";

            cmbWarehouse.DataSource = warehouses.ToList();
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.ValueMember = "Id";
        }

        private void ResetFormInput()
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        private async Task FillFrom(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            txtCode.Text = item.Code;
            txtName.Text = item.Name;
            cmbUnit.SelectedItem = item.MeasurementUnit;
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Please enter an item name and code.");
                    return;
                }

                if (cmbWarehouse.SelectedItem == null)
                {
                    MessageBox.Show("Please select a warehouse.");
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                // Get warehouse selection
                var selectedWarehouse = (Warehouse)cmbWarehouse.SelectedItem;

                // Call service to add the new item
                await _itemService.AddNewItemToWarehouseAsync(
                    txtCode.Text,
                    txtName.Text,
                    selectedWarehouse.Id,
                    quantity,
                    cmbUnit.SelectedItem.ToString()
                );

                MessageBox.Show("New item added successfully!");

                // Refresh DataGridView to show the updated warehouse stock
                dgvItems.DataSource = await _itemService.GetItemsByWarehousesAsync(new List<int> { selectedWarehouse.Id });

                // Clear input fields
                ResetFormInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["ItemId"].Value);
                var item = await _itemService.GetItemByIdAsync(id);

                item.Name = txtName.Text;
                item.Code = txtCode.Text;
                item.MeasurementUnit = cmbUnit.SelectedItem.ToString();

                await _itemService.UpdateItemAsync(id, item.Code, item.Name, item.MeasurementUnit);
                LoadItems();
                ResetFormInput();
            }
        }

        private void dgvItems_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0) // Ensure a row is selected
            {
                int id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["ItemId"].Value);
                FillFrom(id);
            }
        }

        private async void clbWarehouses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            await Task.Delay(100); // Ensure UI updates before fetching data

            // Manually update the selected warehouse list
            var selectedWarehouseIds = clbWarehouses.CheckedItems
                                                    .Cast<Warehouse>()
                                                    .Select(w => w.Id)
                                                    .ToList();

            // Handle the case where an item is being checked or unchecked
            if (e.NewValue == CheckState.Checked)
            {
                var warehouse = (Warehouse)clbWarehouses.Items[e.Index];
                selectedWarehouseIds.Add(warehouse.Id);
            }
            else
            {
                var warehouse = (Warehouse)clbWarehouses.Items[e.Index];
                selectedWarehouseIds.Remove(warehouse.Id);
            }

            if (!selectedWarehouseIds.Any()) return; // No warehouses selected, exit early

            // Fetch items from the selected warehouses
            var items = await _itemService.GetItemsByWarehousesAsync(selectedWarehouseIds);

            // Clear DataGridView
            dgvItems.DataSource = null;
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();
            dgvItems.Refresh();

            // Bind the new data
            dgvItems.DataSource = items;
        }

    }
}
