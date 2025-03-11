using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.Business.Interfaces;
using WarehouseManagementSystem.Business.Services;
using WarehouseManagementSystem.Data;
using WarehouseManagementSystem.Data.UOW;
using WarehouseManagementSystem.Data.UOW.Interfaces;

namespace WarehouseManagementSystem.Presenation.Forms;

public partial class CustomerForm : Form
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CustomerService _customerService;
    public CustomerForm()
    {
        InitializeComponent();

        _unitOfWork = new UnitOfWork(new WMSDbContext());
        _customerService = new CustomerService(_unitOfWork);
    }

    private async Task LoadCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        dgvCustomers.DataSource = customers;
        dgvCustomers.Columns["Id"].Visible = false;
        dgvCustomers.AllowUserToAddRows = false;
        dgvCustomers.ReadOnly = true;
    }

    private void ResetFormInput()
    {
        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPhone.Text = string.Empty;
    }

    private async Task FillFrom(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        txtName.Text = customer.Name;
        txtPhone.Text = customer.Phone;
        txtEmail.Text = customer.Email;
    }

    private async void CustomerForm_Load(object sender, EventArgs e)
    {
        await LoadCustomers();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            await _customerService.AddCustomerAsync(txtName.Text, txtPhone.Text, txtEmail.Text);
            await LoadCustomers();
            ResetFormInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvCustomers.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

            try
            {
                await _customerService.UpdateCustomerAsync(id, txtName.Text, txtPhone.Text, txtEmail.Text);
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadCustomers();
                ResetFormInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

    private async void dgvCustomers_Click(object sender, EventArgs e)
    {
        if (dgvCustomers.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            await FillFrom(id);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvCustomers.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _customerService.DeleteCustomerAsync(id);
                    MessageBox.Show("customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}