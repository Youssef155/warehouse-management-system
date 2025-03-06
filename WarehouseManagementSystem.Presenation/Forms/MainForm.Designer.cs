namespace WarehouseManagementSystem.Presenation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SidePanal = new Panel();
            btnStockTransfer = new FontAwesome.Sharp.IconButton();
            btnWithdrawalOrder = new FontAwesome.Sharp.IconButton();
            btnSupplyOrder = new FontAwesome.Sharp.IconButton();
            btnCustomer = new FontAwesome.Sharp.IconButton();
            btnSupplier = new FontAwesome.Sharp.IconButton();
            btnItems = new FontAwesome.Sharp.IconButton();
            btnWarehouse = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panelContainer = new Panel();
            SidePanal.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SidePanal
            // 
            SidePanal.BackColor = Color.Black;
            SidePanal.Controls.Add(btnStockTransfer);
            SidePanal.Controls.Add(btnWithdrawalOrder);
            SidePanal.Controls.Add(btnSupplyOrder);
            SidePanal.Controls.Add(btnCustomer);
            SidePanal.Controls.Add(btnSupplier);
            SidePanal.Controls.Add(btnItems);
            SidePanal.Controls.Add(btnWarehouse);
            SidePanal.Controls.Add(panel1);
            SidePanal.Dock = DockStyle.Left;
            SidePanal.Location = new Point(0, 0);
            SidePanal.Name = "SidePanal";
            SidePanal.Size = new Size(220, 747);
            SidePanal.TabIndex = 0;
            // 
            // btnStockTransfer
            // 
            btnStockTransfer.Dock = DockStyle.Top;
            btnStockTransfer.FlatAppearance.BorderSize = 0;
            btnStockTransfer.FlatStyle = FlatStyle.Flat;
            btnStockTransfer.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStockTransfer.ForeColor = Color.WhiteSmoke;
            btnStockTransfer.IconChar = FontAwesome.Sharp.IconChar.ArrowUpFromBracket;
            btnStockTransfer.IconColor = Color.WhiteSmoke;
            btnStockTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStockTransfer.ImageAlign = ContentAlignment.MiddleLeft;
            btnStockTransfer.Location = new Point(0, 500);
            btnStockTransfer.Name = "btnStockTransfer";
            btnStockTransfer.Padding = new Padding(10, 0, 20, 0);
            btnStockTransfer.Size = new Size(220, 60);
            btnStockTransfer.TabIndex = 7;
            btnStockTransfer.Text = "Stock Transfer";
            btnStockTransfer.TextAlign = ContentAlignment.MiddleLeft;
            btnStockTransfer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStockTransfer.UseVisualStyleBackColor = true;
            btnStockTransfer.Click += btnStockTransfer_Click;
            // 
            // btnWithdrawalOrder
            // 
            btnWithdrawalOrder.Dock = DockStyle.Top;
            btnWithdrawalOrder.FlatAppearance.BorderSize = 0;
            btnWithdrawalOrder.FlatStyle = FlatStyle.Flat;
            btnWithdrawalOrder.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWithdrawalOrder.ForeColor = Color.WhiteSmoke;
            btnWithdrawalOrder.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            btnWithdrawalOrder.IconColor = Color.WhiteSmoke;
            btnWithdrawalOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnWithdrawalOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnWithdrawalOrder.Location = new Point(0, 440);
            btnWithdrawalOrder.Name = "btnWithdrawalOrder";
            btnWithdrawalOrder.Padding = new Padding(10, 0, 20, 0);
            btnWithdrawalOrder.Size = new Size(220, 60);
            btnWithdrawalOrder.TabIndex = 6;
            btnWithdrawalOrder.Text = "Withdrawal Order";
            btnWithdrawalOrder.TextAlign = ContentAlignment.MiddleLeft;
            btnWithdrawalOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWithdrawalOrder.UseVisualStyleBackColor = true;
            btnWithdrawalOrder.Click += btnWithdrawalOrder_Click;
            // 
            // btnSupplyOrder
            // 
            btnSupplyOrder.Dock = DockStyle.Top;
            btnSupplyOrder.FlatAppearance.BorderSize = 0;
            btnSupplyOrder.FlatStyle = FlatStyle.Flat;
            btnSupplyOrder.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSupplyOrder.ForeColor = Color.WhiteSmoke;
            btnSupplyOrder.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            btnSupplyOrder.IconColor = Color.WhiteSmoke;
            btnSupplyOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSupplyOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplyOrder.Location = new Point(0, 380);
            btnSupplyOrder.Name = "btnSupplyOrder";
            btnSupplyOrder.Padding = new Padding(10, 0, 20, 0);
            btnSupplyOrder.Size = new Size(220, 60);
            btnSupplyOrder.TabIndex = 5;
            btnSupplyOrder.Text = "Supply Order";
            btnSupplyOrder.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplyOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplyOrder.UseVisualStyleBackColor = true;
            btnSupplyOrder.Click += btnSupplyOrder_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomer.ForeColor = Color.WhiteSmoke;
            btnCustomer.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnCustomer.IconColor = Color.WhiteSmoke;
            btnCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomer.Location = new Point(0, 320);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(10, 0, 20, 0);
            btnCustomer.Size = new Size(220, 60);
            btnCustomer.TabIndex = 4;
            btnCustomer.Text = "Customer";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Dock = DockStyle.Top;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSupplier.ForeColor = Color.WhiteSmoke;
            btnSupplier.IconChar = FontAwesome.Sharp.IconChar.Truck;
            btnSupplier.IconColor = Color.WhiteSmoke;
            btnSupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplier.Location = new Point(0, 260);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Padding = new Padding(10, 0, 20, 0);
            btnSupplier.Size = new Size(220, 60);
            btnSupplier.TabIndex = 3;
            btnSupplier.Text = "Supplier";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnItems
            // 
            btnItems.Dock = DockStyle.Top;
            btnItems.FlatAppearance.BorderSize = 0;
            btnItems.FlatStyle = FlatStyle.Flat;
            btnItems.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnItems.ForeColor = Color.WhiteSmoke;
            btnItems.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            btnItems.IconColor = Color.WhiteSmoke;
            btnItems.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnItems.ImageAlign = ContentAlignment.MiddleLeft;
            btnItems.Location = new Point(0, 200);
            btnItems.Name = "btnItems";
            btnItems.Padding = new Padding(10, 0, 20, 0);
            btnItems.Size = new Size(220, 60);
            btnItems.TabIndex = 2;
            btnItems.Text = "Items";
            btnItems.TextAlign = ContentAlignment.MiddleLeft;
            btnItems.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnItems.UseVisualStyleBackColor = true;
            btnItems.Click += btnItems_Click;
            // 
            // btnWarehouse
            // 
            btnWarehouse.Dock = DockStyle.Top;
            btnWarehouse.FlatAppearance.BorderSize = 0;
            btnWarehouse.FlatStyle = FlatStyle.Flat;
            btnWarehouse.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWarehouse.ForeColor = Color.WhiteSmoke;
            btnWarehouse.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            btnWarehouse.IconColor = Color.WhiteSmoke;
            btnWarehouse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnWarehouse.ImageAlign = ContentAlignment.MiddleLeft;
            btnWarehouse.Location = new Point(0, 140);
            btnWarehouse.Name = "btnWarehouse";
            btnWarehouse.Padding = new Padding(10, 0, 20, 0);
            btnWarehouse.Size = new Size(220, 60);
            btnWarehouse.TabIndex = 1;
            btnWarehouse.Text = "Warehouse";
            btnWarehouse.TextAlign = ContentAlignment.MiddleLeft;
            btnWarehouse.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWarehouse.UseVisualStyleBackColor = true;
            btnWarehouse.Click += btnWarehouse_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 20, 0);
            panel1.Size = new Size(220, 140);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(204, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(220, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1200, 747);
            panelContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 747);
            Controls.Add(panelContainer);
            Controls.Add(SidePanal);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            SidePanal.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel SidePanal;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnWarehouse;
        private FontAwesome.Sharp.IconButton btnStockTransfer;
        private FontAwesome.Sharp.IconButton btnWithdrawalOrder;
        private FontAwesome.Sharp.IconButton btnSupplyOrder;
        private FontAwesome.Sharp.IconButton btnCustomer;
        private FontAwesome.Sharp.IconButton btnSupplier;
        private FontAwesome.Sharp.IconButton btnItems;
        private PictureBox pictureBox1;
        private Panel panelContainer;
    }
}