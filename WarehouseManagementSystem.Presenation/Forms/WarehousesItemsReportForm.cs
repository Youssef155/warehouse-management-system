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
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.UOW.Interfaces;
using AspNetCore.Reporting;
using WarehouseManagementSystem.Data.Models;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class WarehousesItemsReportForm : Form
    {
        private readonly WarehouseService _warehouseService;
        private readonly IUnitOfWork _unitOfWork;
        public WarehousesItemsReportForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new WMSDbContext());
            _warehouseService = new WarehouseService(_unitOfWork);
            LoadWarehouses();
        }

        private async Task LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();

            clbWarehouses.DataSource = warehouses;
            clbWarehouses.DisplayMember = "Name";
            clbWarehouses.ValueMember = "Id";
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedWarehouseIds = clbWarehouses.CheckedItems
                     .Cast<Warehouse>()
                     .Select(item => item.Id)
                     .ToList();

                if (selectedWarehouseIds.Count == 0)
                {
                    MessageBox.Show("Please select at least one warehouse.");
                    return;
                }

                // Load the RDLC file
                string reportPath = Path.Combine(Application.StartupPath, @"E:\ITI\Projects\WarehouseManagementSystem\WarehouseManagementSystem.Presenation\Reports\WarehousesItemsReport.rdlc");
                LocalReport report = new LocalReport(reportPath);

                // Get the data from the service
                var dataTable = await _warehouseService.GetItemsReport(selectedWarehouseIds);

                // Add the data source to the report
                report.AddDataSource("WarehousesItemsDataSet", dataTable);

                // Render the report to PDF
                var result = report.Execute(RenderType.Pdf);

                // Save the PDF file
                string pdfPath = Path.Combine(Application.StartupPath, $"WarehouseItemsReport_{selectedWarehouseIds}.pdf");
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
