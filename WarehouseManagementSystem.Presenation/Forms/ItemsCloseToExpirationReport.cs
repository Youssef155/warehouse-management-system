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
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms
{
    public partial class ItemsCloseToExpirationReport : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ItemService _itemService;
        public ItemsCloseToExpirationReport()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new Data.WMSDbContext());
            _itemService = new ItemService(_unitOfWork);
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                int daysThreshold = (int)nudDaysThreshold.Value;

                if (daysThreshold <= 0)
                {
                    MessageBox.Show("Please enter a valid number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dataTable = await _itemService.GetItemsCloseToExpirationAsync(daysThreshold);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No items found close to expiration.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Load the RDLC file
                string reportPath = Path.Combine(Application.StartupPath, @"E:\ITI\Projects\WarehouseManagementSystem\WarehouseManagementSystem.Presenation\Reports\ItemsCloseToExpirationReport.rdlc");
                LocalReport report = new LocalReport(reportPath);

                // Add the data source
                report.AddDataSource("ItemsCloseToExpirationDataSet", dataTable);

                // Render the report to PDF
                var result = report.Execute(RenderType.Pdf);

                // Save the PDF file
                string pdfPath = Path.Combine(Application.StartupPath, $"ItemsCloseToExpirationReport_{DateTime.Now:yyyyMMddHHmmss}.pdf");
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
