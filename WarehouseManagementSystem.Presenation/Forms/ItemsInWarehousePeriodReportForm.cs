using AspNetCore.Reporting;
using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Data.Models;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class ItemsInWarehousePeriodReportForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WarehouseService _warehouseService;
        public ItemsInWarehousePeriodReportForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new Data.WMSDbContext());
            _warehouseService = new WarehouseService(_unitOfWork);

            LoadWarehouses();
        }

        private async Task LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();

            cmbWarehouses.DataSource = warehouses;
            cmbWarehouses.DisplayMember = "Name";
            cmbWarehouses.ValueMember = "Id";
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected warehouse ID
                if (cmbWarehouses.SelectedItem is not Warehouse selectedWarehouse)
                {
                    MessageBox.Show("Please select a warehouse.");
                    return;
                }

                // Get the date range from the UI
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;

                // Get the data from the service
                var dataTable = await _warehouseService.GetItemsInWarehouseForPeriod(selectedWarehouse.Id, fromDate, toDate);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No items found for the selected warehouse and period.");
                    return;
                }

                // Load the RDLC file
                string reportPath = Path.Combine(Application.StartupPath, @"Reports\ItemsInWarehouseForPeriodReport.rdlc");
                LocalReport report = new LocalReport(reportPath);

                // Add the data source to the report
                report.AddDataSource("ItemsInWarehouseForPeriodDataSet", dataTable);

                // Render the report to PDF
                var result = report.Execute(RenderType.Pdf);

                // Save the PDF file
                string pdfPath = Path.Combine(Application.StartupPath, $"ItemsInWarehouseForPeriodReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                File.WriteAllBytes(pdfPath, result.MainStream);

                MessageBox.Show($"Report generated successfully!\nSaved at: {pdfPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
