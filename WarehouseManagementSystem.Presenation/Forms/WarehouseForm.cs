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

namespace WarehouseManagementSystem.Presenation.Forms;

public partial class WarehouseForm : Form
{
    private readonly WarehouseService _warehouseService;
    private readonly IUnitOfWork _unitOfWork;

    public WarehouseForm()
    {
        InitializeComponent();
        _unitOfWork = new UnitOfWork(new WMSDbContext());
        _warehouseService = new WarehouseService(_unitOfWork);
        LoadWarehouses();
    }

    private async Task LoadWarehouses()
    {
        var warehouseList = await _warehouseService.GetAllWarehousesAsync();

        dgvWarehouses.DataSource = warehouseList;

        dgvWarehouses.Columns["Id"].Visible = false;
        dgvWarehouses.AllowUserToDeleteRows = false;
        dgvWarehouses.ReadOnly = true;
    }

    private void ResetFormInput()
    {
        txtName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtManager.Text = string.Empty;
    }

    private async Task FillFrom(int id)
    {
        var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
        txtManager.Text = warehouse.Manager;
        txtName.Text = warehouse.Name;
        txtAddress.Text = warehouse.Address;
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            await _warehouseService.AddWarehouseAsync(txtName.Text, txtAddress.Text, txtManager.Text);
            //MessageBox.Show("Warehouse added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWarehouses(); // Refresh DataGridView
            ResetFormInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvWarehouses.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvWarehouses.SelectedRows[0].Cells["Id"].Value);

            try
            {
                await _warehouseService.UpdateWarehouseAsync(id, txtName.Text, txtAddress.Text, txtManager.Text);
                MessageBox.Show("Warehouse updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadWarehouses();
                ResetFormInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvWarehouses.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvWarehouses.SelectedRows[0].Cells["Id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this warehouse?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _warehouseService.DeleteWarehouseAsync(id);
                    MessageBox.Show("Warehouse deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWarehouses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void dgvWarehouses_Click(object sender, EventArgs e)
    {
        if (dgvWarehouses.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvWarehouses.SelectedRows[0].Cells["Id"].Value);
            FillFrom(id);
        }
    }
}
