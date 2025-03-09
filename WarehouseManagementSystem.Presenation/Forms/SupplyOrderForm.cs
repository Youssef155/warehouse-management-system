using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Core.DTOs;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms;

public partial class SupplyOrderForm : Form
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SupplyOrderService _supplyOrderService;
    private readonly WarehouseService _warehouseService;
    private readonly SupplierService _supplierService;

    public SupplyOrderForm()
    {
        InitializeComponent();

        _unitOfWork = new UnitOfWork(new WMSDbContext());
        _supplyOrderService = new SupplyOrderService(_unitOfWork);
        _warehouseService = new WarehouseService(_unitOfWork);
        _supplierService = new SupplierService(_unitOfWork);
    }
    private async Task LoadData()
    {
        var orders = await _supplyOrderService.GetAllSupplyOrdersDetailsAsync();
        dgvSupplyOrder.DataSource = orders;

        var warehouses = await _warehouseService.GetAllWarehousesAsync();
        cmbWarehouses.DataSource = null;
        cmbWarehouses.DataSource = warehouses;
        cmbWarehouses.DisplayMember = "Name";
        cmbWarehouses.ValueMember = "Id";

        var suppliers = await _supplierService.GetAllSuppliersAsync();
        cmbSuppliers.DataSource = null;
        cmbSuppliers.DataSource = suppliers;
        cmbSuppliers.DisplayMember = "Name";
        cmbSuppliers.ValueMember = "Id";
    }

    private void SetupDataGridView()
    {
        dgvSupplyOrder.AutoGenerateColumns = false;

        dgvSupplyOrder.Columns.Clear();

        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderNumber", HeaderText = "Order #" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderDate", HeaderText = "Date" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "Supplier" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WarehouseName", HeaderText = "Warehouse" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemName", HeaderText = "Item" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Quantity" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductionDate", HeaderText = "Production Date" });
        dgvSupplyOrder.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExpirationDate", HeaderText = "Expiration Date" });

        dgvSupplyOrder.AllowUserToAddRows = false;
        dgvSupplyOrder.ReadOnly = true;
    }

    private async void SupplyOrderForm_Load(object sender, EventArgs e)
    {
        await LoadData();
        SetupDataGridView();
    }

    private async void btnAddOrder_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtItemCode.Text) || string.IsNullOrWhiteSpace(txtItemName.Text))
        {
            MessageBox.Show("Please enter an item code and name.");
            return;
        }

        var orderDto = new SupplyOrderDto
        {
            SupplierId = (int)cmbSuppliers.SelectedValue,
            WarehouseId = (int)cmbWarehouses.SelectedValue,
            ItemCode = txtItemCode.Text.Trim(),
            ItemName = txtItemName.Text.Trim(),
            MeasurementUnit = cmbMeasurementUnit.Text,
            Quantity = Convert.ToInt32(txtItemQty.Text),
            ProductionDate = dtpProductionDate.Value,
            ExpirationDate = dtpExpirationDate.Value,
        };

        try
        {
            await _supplyOrderService.AddSupplyOrderAsync(orderDto);
            MessageBox.Show("Supply Order added successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }
}
