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
    public partial class SupplierForm : Form
    {
        private readonly SupplierService _supplierService;
        private readonly IUnitOfWork _unitOfWork;
        public SupplierForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new WMSDbContext());
            _supplierService = new SupplierService(_unitOfWork);
        }

        private async Task LoadSuppliers()
        {
            var suppliers = _supplierService.GetAllSuppliersAsync();
            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = suppliers;
        }

        private void SetupDataGridView()
        {
            dgvSupplier.AutoGenerateColumns = false;

            dgvSupplier.Columns.Clear();

            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone" });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Mobile", HeaderText = "Mobile" });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fax", HeaderText = "Fax" });
            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Website", HeaderText = "Website" });
            
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.AllowUserToDeleteRows = false;
            dgvSupplier.ReadOnly = true;
        }

        private void ResetInputs()
        {
            txtSupplierName.Text = string.Empty;
            txtSupplierPhone.Text = string.Empty;
            txtSupplierEmail.Text = string.Empty; 
            txtSupplierTax.Text = string.Empty;
            txtSupplierWebsite.Text = string.Empty;
            txtSupplierMobile.Text = string.Empty;
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliers();
            SetupDataGridView();
        }

        private async void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                await _supplierService.AddSupplierAsync(txtSupplierName.Text, txtSupplierPhone.Text,
                            txtSupplierEmail.Text, txtSupplierTax.Text, txtSupplierMobile.Text, 
                            txtSupplierWebsite.Text);

                await LoadSuppliers();
                ResetInputs();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
