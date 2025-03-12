using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class WarehouseStateReportForm : Form
    {
        private readonly WarehouseService _warehouseService;
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseStateReportForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new WMSDbContext());
            _warehouseService = new WarehouseService(_unitOfWork);
            LoadWarehouses();
        }

        private async Task LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            comboBoxWarehouses.DataSource = warehouses;
            comboBoxWarehouses.DisplayMember = "Name";
            comboBoxWarehouses.ValueMember = "Id";
        }

        private async void btnGenerateReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                int warehouseId = (int)comboBoxWarehouses.SelectedValue;

                // Load the RDLC file
                string reportPath = Path.Combine(Application.StartupPath, @"E:\ITI\Projects\WarehouseManagementSystem\WarehouseManagementSystem.Presenation\Reports\WarehouseStatusReport.rdlc");
                LocalReport report = new LocalReport(reportPath);

                // Get the data from the service
                DataTable dataTable = await _warehouseService.GetWarehouseStatusReport(warehouseId);

                // Add the data source to the report
                report.AddDataSource("WarehouseStatusDataSet", dataTable);

                // Render the report to PDF
                var result = report.Execute(RenderType.Pdf);

                // Save the PDF file
                string pdfPath = Path.Combine(Application.StartupPath, $"WarehouseStatusReport_{warehouseId}.pdf");
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
