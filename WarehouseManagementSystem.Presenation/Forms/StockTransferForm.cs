using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class StockTransferForm : Form
    {
        private readonly StockTransferService _stockTransferService;
        private readonly ItemService _itemService;
        private readonly UnitOfWork _unitOfWork;

        public StockTransferForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new WMSDbContext());
            _stockTransferService = new StockTransferService(_unitOfWork);
            _itemService = new ItemService(_unitOfWork);
        }

        private void InitializeDataGridView()
        {
            dgvStockItems.Columns.Clear();
            dgvStockItems.AutoGenerateColumns = false;
            dgvStockItems.AllowUserToDeleteRows = false;

            // Checkbox column for selection
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "✔",
                Width = 40
            };
            dgvStockItems.Columns.Add(chkColumn);

            // Item Id column
            dgvStockItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemId",
                HeaderText = "Item Id",
                DataPropertyName = "ItemId",
                ReadOnly = true,
                Width = 150,
                Visible = false
            });

            // Item Name column
            dgvStockItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemName",
                HeaderText = "Item Name",
                DataPropertyName = "ItemName",
                ReadOnly = true,
                Width = 150
            });

            // Available Quantity column
            dgvStockItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AvailableQuantity",
                HeaderText = "Available Qty",
                DataPropertyName = "Quantity",
                ReadOnly = true,
                Width = 120
            });

            // Production Date column
            dgvStockItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductionDate",
                HeaderText = "Production Date",
                DataPropertyName = "ProductionDate",
                ReadOnly = true,
                Width = 200
            });

            // Expiration Date column
            dgvStockItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExpirationDate",
                HeaderText = "Expiration Date",
                DataPropertyName = "ExpirationDate",
                ReadOnly = true,
                Width = 200
            });

            // Transfer Quantity column (Editable)
            DataGridViewTextBoxColumn transferQtyColumn = new DataGridViewTextBoxColumn
            {
                Name = "TransferQuantity",
                HeaderText = "Transfer Qty",
                Width = 120
            };
            dgvStockItems.Columns.Add(transferQtyColumn);
        }

        private async void LoadStockItems(int warehouseId)
        {
            dgvStockItems.Rows.Clear(); // Clear existing rows

            var stockItems = await _itemService.GetItemsByWarehouseIdAsync(warehouseId);

            foreach (var stock in stockItems)
            {
                dgvStockItems.Rows.Add(false,
                                       stock.ItemId,
                                       stock.ItemName,
                                       stock.Quantity,
                                       stock.ProductionDate.ToShortDateString(),  // Get from StockItem
                                       stock.ExpirationDate.ToShortDateString(),  // Get from StockItem
                                       0); // Default transfer quantity = 0
            }
        }

        private async Task LoadWarehousesIntoCmb()
        {
            try
            {
                var warehouses = await _unitOfWork.Warehouses.GetAllAsync();
                if (warehouses == null || !warehouses.Any())
                {
                    MessageBox.Show("No warehouses found.");
                    return;
                }

                // Clone the list to prevent reference issues
                cmbSourceWarehouse.DataSource = null;
                cmbSourceWarehouse.DataSource = warehouses.ToList();
                cmbSourceWarehouse.DisplayMember = "Name";
                cmbSourceWarehouse.ValueMember = "Id";

                cmbDestinationWarehouse.DataSource = null;
                cmbDestinationWarehouse.DataSource = warehouses.ToList();
                cmbDestinationWarehouse.DisplayMember = "Name";
                cmbDestinationWarehouse.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading warehouses: {ex.Message}");
            }
        }

        private async void btnLoadItems_Click(object sender, EventArgs e)
        {
            int sourceWarehouseId = (int)cmbSourceWarehouse.SelectedValue;

            LoadStockItems(sourceWarehouseId);
        }

        private async void btnTransferStock_Click(object sender, EventArgs e)
        {
            if (cmbSourceWarehouse.SelectedItem == null || cmbDestinationWarehouse.SelectedItem == null)
            {
                MessageBox.Show("Please select both source and destination warehouses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sourceWarehouseId = ((Warehouse)cmbSourceWarehouse.SelectedItem).Id;
            int destinationWarehouseId = ((Warehouse)cmbDestinationWarehouse.SelectedItem).Id;

            if (sourceWarehouseId == destinationWarehouseId)
            {
                MessageBox.Show("Source and destination warehouses cannot be the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var selectedItems = new List<StockTransferDto>();
            StockTransferDto transferDto = new StockTransferDto();

            foreach (DataGridViewRow row in dgvStockItems.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value)) // Checkbox is checked
                {
                    int itemId = (int)row.Cells["ItemId"].Value;
                    int availableQuantity = (int)row.Cells["AvailableQuantity"].Value;
                    DateTime expirationDate = DateTime.Parse(row.Cells["ExpirationDate"].Value.ToString());

                    int transferQuantity;
                    if (!int.TryParse(row.Cells["TransferQuantity"].Value?.ToString(), out transferQuantity) || transferQuantity <= 0)
                    {
                        MessageBox.Show($"Invalid transfer quantity for {row.Cells["ItemName"].Value}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (transferQuantity > availableQuantity)
                    {
                        MessageBox.Show($"Transfer quantity exceeds available stock for {row.Cells["ItemName"].Value}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (expirationDate < DateTime.Today)
                    {
                        MessageBox.Show($"Cannot transfer expired item: {row.Cells["ItemName"].Value}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    transferDto.Items.Add(new StockTransferItemDto
                    {
                        ItemId = itemId,
                        Quantity = transferQuantity,
                    });

                    transferDto.DestinationWarehouseId = destinationWarehouseId;
                    transferDto.SourceWarehouseId = sourceWarehouseId;
                    transferDto.ProductionDate = DateTime.Parse(row.Cells["ProductionDate"].Value.ToString());
                    transferDto.ExpirationDate = expirationDate;
                    transferDto.TransferDate = DateTime.UtcNow;

                    //selectedItems.Add(new StockTransferDto
                    //{
                    //    ItemId = itemId,
                    //    SourceWarehouseId = sourceWarehouseId,
                    //    DestinationWarehouseId = destinationWarehouseId,
                    //    TransferQuantity = transferQuantity,
                    //    ProductionDate = DateTime.Parse(row.Cells["ProductionDate"].Value.ToString()),
                    //    ExpirationDate = expirationDate,
                    //    TransferDate = DateTime.UtcNow
                    //});
                }
            }

            if (transferDto.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one item to transfer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Call Business Logic to Handle the Transfer
            bool success = await _stockTransferService.TransferStockAsync(transferDto);

            if (success)
            {
                MessageBox.Show("Stock transferred successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStockItems(sourceWarehouseId); // Refresh grid after transfer
            }
            else
            {
                MessageBox.Show("Failed to transfer stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockTransferForm_Load(object sender, EventArgs e)
        {
            LoadWarehousesIntoCmb();
            InitializeDataGridView();
        }
    }
}
