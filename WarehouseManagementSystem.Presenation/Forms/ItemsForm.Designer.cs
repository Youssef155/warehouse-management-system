namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class ItemsForm
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
            dgvItems = new DataGridView();
            txtName = new TextBox();
            txtCode = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbUnit = new ComboBox();
            label3 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            label4 = new Label();
            clbWarehouses = new CheckedListBox();
            label5 = new Label();
            cmbWarehouse = new ComboBox();
            label6 = new Label();
            txtQuantity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.BackgroundColor = SystemColors.Window;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 367);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.Size = new Size(1004, 132);
            dgvItems.TabIndex = 0;
            dgvItems.Click += dgvItems_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(67, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(234, 27);
            txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(67, 93);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(234, 27);
            txtCode.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 4;
            label2.Text = "Code";
            // 
            // cmbUnit
            // 
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Location = new Point(472, 31);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(252, 28);
            cmbUnit.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(336, 34);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 6;
            label3.Text = "Measurement Unit";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(922, 79);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(922, 126);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.Lime;
            btnAdd.ForeColor = SystemColors.ActiveCaptionText;
            btnAdd.Location = new Point(922, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 222);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 14;
            label4.Text = "Filter by warehouses";
            // 
            // clbWarehouses
            // 
            clbWarehouses.FormattingEnabled = true;
            clbWarehouses.Location = new Point(166, 219);
            clbWarehouses.Name = "clbWarehouses";
            clbWarehouses.Size = new Size(187, 114);
            clbWarehouses.TabIndex = 15;
            clbWarehouses.ItemCheck += clbWarehouses_ItemCheck;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(739, 34);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 17;
            label5.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.FormattingEnabled = true;
            cmbWarehouse.Location = new Point(875, 31);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(252, 28);
            cmbWarehouse.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(401, 96);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 19;
            label6.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(472, 93);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(234, 27);
            txtQuantity.TabIndex = 20;
            // 
            // ItemsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 530);
            Controls.Add(txtQuantity);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbWarehouse);
            Controls.Add(clbWarehouses);
            Controls.Add(label4);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(cmbUnit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCode);
            Controls.Add(txtName);
            Controls.Add(dgvItems);
            Name = "ItemsForm";
            Text = "ItemsForm";
            Load += ItemsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItems;
        private TextBox txtName;
        private TextBox txtCode;
        private Label label1;
        private Label label2;
        private ComboBox cmbUnit;
        private Label label3;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Label label4;
        private CheckedListBox clbWarehouses;
        private Label label5;
        private ComboBox cmbWarehouse;
        private Label label6;
        private TextBox txtQuantity;
    }
}