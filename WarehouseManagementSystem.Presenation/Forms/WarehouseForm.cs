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

namespace WarehouseManagementSystem.Presenation.Forms;

public partial class WarehouseForm : Form
{
    private readonly WarehouseService _warehouseService;

    public WarehouseForm()
    {
        InitializeComponent();
        _warehouseService = new WarehouseService(new UnitOfWork(new WMSDbContext()));
        LoadWarehouses();
    }

    private void LoadWarehouses()
    {
        dgvWarehouses.DataSource = _warehouseService.GetAllWarehouses().ToList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            _warehouseService.AddWarehouse(txtName.Text, txtAddress.Text, txtManager.Text);
            MessageBox.Show("Warehouse added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWarehouses(); // Refresh DataGridView
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvWarehouses.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvWarehouses.SelectedRows[0].Cells["Id"].Value);

            try
            {
                _warehouseService.UpdateWarehouse(id, txtName.Text, txtAddress.Text, txtManager.Text);
                MessageBox.Show("Warehouse updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWarehouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvWarehouses.SelectedRows.Count > 0)
        {
            int id = Convert.ToInt32(dgvWarehouses.SelectedRows[0].Cells["Id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this warehouse?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _warehouseService.DeleteWarehouse(id);
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
}
