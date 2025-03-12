namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class WithdrawalOrderForm
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
            dgvOrders = new DataGridView();
            txtOrderId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            dtpOrderDate = new DateTimePicker();
            cmbWarehouses = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.BackgroundColor = SystemColors.Window;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(50, 304);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1234, 188);
            dgvOrders.TabIndex = 0;
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(375, 73);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(125, 27);
            txtOrderId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 74);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Order Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 219);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 5;
            label2.Text = "Warehouse";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 144);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 6;
            label3.Text = "Order Date";
            // 
            // button1
            // 
            button1.Location = new Point(759, 81);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(759, 158);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new Point(375, 144);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(250, 27);
            dtpOrderDate.TabIndex = 9;
            // 
            // cmbWarehouses
            // 
            cmbWarehouses.FormattingEnabled = true;
            cmbWarehouses.Location = new Point(375, 219);
            cmbWarehouses.Name = "cmbWarehouses";
            cmbWarehouses.Size = new Size(151, 28);
            cmbWarehouses.TabIndex = 10;
            // 
            // WithdrawalOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 582);
            Controls.Add(cmbWarehouses);
            Controls.Add(dtpOrderDate);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtOrderId);
            Controls.Add(dgvOrders);
            Name = "WithdrawalOrderForm";
            Text = "WithdrawalOrderForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private TextBox txtOrderId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private DateTimePicker dtpOrderDate;
        private ComboBox cmbWarehouses;
    }
}