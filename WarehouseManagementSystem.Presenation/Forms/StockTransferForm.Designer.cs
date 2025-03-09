namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class StockTransferForm
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
            dgvStockItems = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cmbSourceWarehouse = new ComboBox();
            cmbDestinationWarehouse = new ComboBox();
            btnLoadItems = new Button();
            btnTransferStock = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStockItems).BeginInit();
            SuspendLayout();
            // 
            // dgvStockItems
            // 
            dgvStockItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStockItems.BackgroundColor = SystemColors.Window;
            dgvStockItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockItems.Location = new Point(12, 216);
            dgvStockItems.Name = "dgvStockItems";
            dgvStockItems.RowHeadersWidth = 51;
            dgvStockItems.Size = new Size(1297, 241);
            dgvStockItems.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 82);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Source Warehouse";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(690, 82);
            label2.Name = "label2";
            label2.Size = new Size(206, 20);
            label2.TabIndex = 2;
            label2.Text = "Select Destination Warehouse";
            // 
            // cmbSourceWarehouse
            // 
            cmbSourceWarehouse.FormattingEnabled = true;
            cmbSourceWarehouse.Location = new Point(232, 79);
            cmbSourceWarehouse.Name = "cmbSourceWarehouse";
            cmbSourceWarehouse.Size = new Size(223, 28);
            cmbSourceWarehouse.TabIndex = 3;
            // 
            // cmbDestinationWarehouse
            // 
            cmbDestinationWarehouse.FormattingEnabled = true;
            cmbDestinationWarehouse.Location = new Point(902, 79);
            cmbDestinationWarehouse.Name = "cmbDestinationWarehouse";
            cmbDestinationWarehouse.Size = new Size(223, 28);
            cmbDestinationWarehouse.TabIndex = 4;
            // 
            // btnLoadItems
            // 
            btnLoadItems.Location = new Point(1174, 30);
            btnLoadItems.Name = "btnLoadItems";
            btnLoadItems.Size = new Size(135, 44);
            btnLoadItems.TabIndex = 5;
            btnLoadItems.Text = "Load Items";
            btnLoadItems.UseVisualStyleBackColor = true;
            btnLoadItems.Click += btnLoadItems_Click;
            // 
            // btnTransferStock
            // 
            btnTransferStock.Location = new Point(1174, 120);
            btnTransferStock.Name = "btnTransferStock";
            btnTransferStock.Size = new Size(135, 44);
            btnTransferStock.TabIndex = 6;
            btnTransferStock.Text = "Execute Transfer";
            btnTransferStock.UseVisualStyleBackColor = true;
            btnTransferStock.Click += btnTransferStock_Click;
            // 
            // StockTransferForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 519);
            Controls.Add(btnTransferStock);
            Controls.Add(btnLoadItems);
            Controls.Add(cmbDestinationWarehouse);
            Controls.Add(cmbSourceWarehouse);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvStockItems);
            Name = "StockTransferForm";
            Text = "StockTransferForm";
            Load += StockTransferForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStockItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStockItems;
        private Label label1;
        private Label label2;
        private ComboBox cmbSourceWarehouse;
        private ComboBox cmbDestinationWarehouse;
        private Button btnLoadItems;
        private Button btnTransferStock;
    }
}