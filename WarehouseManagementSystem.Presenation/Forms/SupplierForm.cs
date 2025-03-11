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
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = suppliers;

            dgvSupplier.Columns["Id"].Visible = false;
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

        private async Task FillFrom(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            txtSupplierName.Text = supplier.Name;
            txtSupplierPhone.Text = supplier.Phone;
            txtSupplierEmail.Text = supplier.Email;
            txtSupplierMobile.Text = supplier.Mobile;
            txtSupplierTax.Text = supplier.Fax;
            txtSupplierWebsite.Text = supplier.Website;
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliers();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["Id"].Value);

                try
                {
                    await _supplierService.UpdateSupplierAsync(id, txtSupplierName.Text, txtSupplierPhone.Text,
                        txtSupplierEmail.Text, txtSupplierTax.Text, txtSupplierMobile.Text, txtSupplierWebsite.Text);
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSuppliers();
                    ResetInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private async void dgvSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["Id"].Value);
                await FillFrom(id);
            }
        }

        private async void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["Id"].Value);

                var confirm = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        await _supplierService.DeleteSupplierAsync(id);
                        MessageBox.Show("supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadSuppliers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
