using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms;

public partial class SupplyOrderForm : Form
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SupplyOrderService _supplyOrderService;
    private readonly WarehouseService _warehouseService;

    public SupplyOrderForm()
    {
        InitializeComponent();

        _unitOfWork = new UnitOfWork(new WMSDbContext());
        _supplyOrderService = new SupplyOrderService(_unitOfWork);
        _warehouseService = new WarehouseService(_unitOfWork);
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

        //var suppliers = await
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
}
