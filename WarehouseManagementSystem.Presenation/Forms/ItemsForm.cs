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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class ItemsForm : Form
    {
        private readonly ItemService _itemService;
        public ItemsForm()
        {
            InitializeComponent();
            _itemService = new ItemService(new UnitOfWork(new WMSDbContext()));
            LoadItems();
            cmbUnit.Items.AddRange(new string[] { "Piece", "Kg", "Liter", "Meter" });
            cmbUnit.SelectedIndex = 0;
        }

        private async Task LoadItems()
        {
            dgvItems.DataSource = await _itemService.GetAllItemsAsync();
        }

        private void ResetFormInput()
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
        }

        private async Task FillFrom(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            txtCode.Text = item.Code;
            txtName.Text = item.Name;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await _itemService.AddItemAsync(txtName.Text, txtCode.Text, cmbUnit.SelectedItem.ToString());
            LoadItems();
            ResetFormInput();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["Id"].Value);
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
            int id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["Id"].Value);
            FillFrom(id);
        }
    }
}
