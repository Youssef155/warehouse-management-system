namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class SupplyOrderForm
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
            dgvSupplyOrder = new DataGridView();
            cmbWarehouses = new ComboBox();
            cmbSuppliers = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dtpOrderDate = new DateTimePicker();
            dtpExpirationDate = new DateTimePicker();
            dtpProductionDate = new DateTimePicker();
            label7 = new Label();
            txtItemCode = new TextBox();
            label8 = new Label();
            txtItemName = new TextBox();
            label9 = new Label();
            txtItemQty = new TextBox();
            btnAddOrder = new Button();
            label10 = new Label();
            cmbMeasurementUnit = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSupplyOrder).BeginInit();
            SuspendLayout();
            // 
            // dgvSupplyOrder
            // 
            dgvSupplyOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSupplyOrder.BackgroundColor = SystemColors.Window;
            dgvSupplyOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplyOrder.Location = new Point(38, 290);
            dgvSupplyOrder.Name = "dgvSupplyOrder";
            dgvSupplyOrder.RowHeadersWidth = 51;
            dgvSupplyOrder.Size = new Size(1294, 231);
            dgvSupplyOrder.TabIndex = 0;
            // 
            // cmbWarehouses
            // 
            cmbWarehouses.FormattingEnabled = true;
            cmbWarehouses.Location = new Point(152, 25);
            cmbWarehouses.Name = "cmbWarehouses";
            cmbWarehouses.Size = new Size(250, 28);
            cmbWarehouses.TabIndex = 7;
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(152, 74);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(250, 28);
            cmbSuppliers.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 33);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 9;
            label1.Text = "Warehouse";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 123);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 11;
            label3.Text = "Order Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 80);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 12;
            label4.Text = "Supplier";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 79);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 13;
            label5.Text = "Production Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(494, 128);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 14;
            label6.Text = "Expiration Date";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new Point(152, 120);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(250, 27);
            dtpOrderDate.TabIndex = 15;
            // 
            // dtpExpirationDate
            // 
            dtpExpirationDate.Location = new Point(611, 125);
            dtpExpirationDate.Name = "dtpExpirationDate";
            dtpExpirationDate.Size = new Size(250, 27);
            dtpExpirationDate.TabIndex = 16;
            // 
            // dtpProductionDate
            // 
            dtpProductionDate.Location = new Point(611, 74);
            dtpProductionDate.Name = "dtpProductionDate";
            dtpProductionDate.Size = new Size(250, 27);
            dtpProductionDate.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(925, 34);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 19;
            label7.Text = "Item Code";
            // 
            // txtItemCode
            // 
            txtItemCode.Location = new Point(1082, 25);
            txtItemCode.Name = "txtItemCode";
            txtItemCode.Size = new Size(250, 27);
            txtItemCode.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(505, 33);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 21;
            label8.Text = "Item Name";
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(611, 25);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(250, 27);
            txtItemName.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(925, 85);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 23;
            label9.Text = "Item Quantity";
            // 
            // txtItemQty
            // 
            txtItemQty.Location = new Point(1082, 76);
            txtItemQty.Name = "txtItemQty";
            txtItemQty.Size = new Size(250, 27);
            txtItemQty.TabIndex = 22;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(611, 198);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(250, 41);
            btnAddOrder.TabIndex = 24;
            btnAddOrder.Text = "Save Order";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(925, 128);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 26;
            label10.Text = "Measurement Unit";
            // 
            // cmbMeasurementUnit
            // 
            cmbMeasurementUnit.FormattingEnabled = true;
            cmbMeasurementUnit.Location = new Point(1082, 120);
            cmbMeasurementUnit.Name = "cmbMeasurementUnit";
            cmbMeasurementUnit.Size = new Size(250, 28);
            cmbMeasurementUnit.TabIndex = 25;
            // 
            // SupplyOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1375, 569);
            Controls.Add(label10);
            Controls.Add(cmbMeasurementUnit);
            Controls.Add(btnAddOrder);
            Controls.Add(label9);
            Controls.Add(txtItemQty);
            Controls.Add(label8);
            Controls.Add(txtItemName);
            Controls.Add(label7);
            Controls.Add(txtItemCode);
            Controls.Add(dtpProductionDate);
            Controls.Add(dtpExpirationDate);
            Controls.Add(dtpOrderDate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cmbSuppliers);
            Controls.Add(cmbWarehouses);
            Controls.Add(dgvSupplyOrder);
            Name = "SupplyOrderForm";
            Text = "SupplyOrderForm";
            Load += SupplyOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSupplyOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSupplyOrder;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private ComboBox cmbWarehouses;
        private ComboBox comboBox1;
        private ComboBox cmbSuppliers;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpOrderDate;
        private DateTimePicker dtpExpirationDate;
        private DateTimePicker dtpProductionDate;
        private Label label7;
        private TextBox txtItemCode;
        private Label label8;
        private TextBox txtItemName;
        private Label label9;
        private TextBox txtItemQty;
        private Button btnAddOrder;
        private Label label10;
        private ComboBox cmbMeasurementUnit;
    }
}