﻿namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class WarehouseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvWarehouses = new DataGridView();
            txtName = new TextBox();
            txtManager = new TextBox();
            txtAddress = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvWarehouses).BeginInit();
            SuspendLayout();
            // 
            // dgvWarehouses
            // 
            dgvWarehouses.BackgroundColor = SystemColors.Window;
            dgvWarehouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarehouses.GridColor = Color.Gray;
            dgvWarehouses.Location = new Point(12, 12);
            dgvWarehouses.Name = "dgvWarehouses";
            dgvWarehouses.RowHeadersWidth = 51;
            dgvWarehouses.Size = new Size(776, 255);
            dgvWarehouses.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 314);
            txtName.Name = "txtName";
            txtName.Size = new Size(239, 27);
            txtName.TabIndex = 1;
            // 
            // txtManager
            // 
            txtManager.Location = new Point(549, 314);
            txtManager.Name = "txtManager";
            txtManager.Size = new Size(239, 27);
            txtManager.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(282, 314);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(239, 27);
            txtAddress.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 291);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 291);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 5;
            label2.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(549, 291);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 6;
            label3.Text = "Manager";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Lime;
            btnAdd.ForeColor = SystemColors.ActiveCaptionText;
            btnAdd.Location = new Point(157, 378);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(549, 378);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(351, 378);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // WarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(txtManager);
            Controls.Add(txtName);
            Controls.Add(dgvWarehouses);
            Name = "WarehouseForm";
            Text = "WarehouseForm";
            ((System.ComponentModel.ISupportInitialize)dgvWarehouses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvWarehouses;
        private TextBox txtName;
        private TextBox txtManager;
        private TextBox txtAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
    }
}