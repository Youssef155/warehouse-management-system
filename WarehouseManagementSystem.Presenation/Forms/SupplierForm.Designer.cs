namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class SupplierForm
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
            dgvSupplier = new DataGridView();
            txtSupplierName = new TextBox();
            txtSupplierPhone = new TextBox();
            txtSupplierMobile = new TextBox();
            txtSupplierWebsite = new TextBox();
            txtSupplierTax = new TextBox();
            txtSupplierEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnAddSupplier = new Button();
            btnDeleteSupplier = new Button();
            btnUpdateSupplier = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // dgvSupplier
            // 
            dgvSupplier.BackgroundColor = SystemColors.Window;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Location = new Point(50, 258);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.RowHeadersWidth = 51;
            dgvSupplier.Size = new Size(1207, 188);
            dgvSupplier.TabIndex = 0;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(50, 76);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(261, 27);
            txtSupplierName.TabIndex = 1;
            // 
            // txtSupplierPhone
            // 
            txtSupplierPhone.Location = new Point(383, 76);
            txtSupplierPhone.Name = "txtSupplierPhone";
            txtSupplierPhone.Size = new Size(261, 27);
            txtSupplierPhone.TabIndex = 2;
            // 
            // txtSupplierMobile
            // 
            txtSupplierMobile.Location = new Point(50, 172);
            txtSupplierMobile.Name = "txtSupplierMobile";
            txtSupplierMobile.Size = new Size(261, 27);
            txtSupplierMobile.TabIndex = 3;
            // 
            // txtSupplierWebsite
            // 
            txtSupplierWebsite.Location = new Point(731, 172);
            txtSupplierWebsite.Name = "txtSupplierWebsite";
            txtSupplierWebsite.Size = new Size(261, 27);
            txtSupplierWebsite.TabIndex = 4;
            // 
            // txtSupplierTax
            // 
            txtSupplierTax.Location = new Point(731, 76);
            txtSupplierTax.Name = "txtSupplierTax";
            txtSupplierTax.Size = new Size(261, 27);
            txtSupplierTax.TabIndex = 5;
            // 
            // txtSupplierEmail
            // 
            txtSupplierEmail.Location = new Point(383, 172);
            txtSupplierEmail.Name = "txtSupplierEmail";
            txtSupplierEmail.Size = new Size(261, 27);
            txtSupplierEmail.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 53);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 149);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 8;
            label2.Text = "Mobile";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(383, 53);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 9;
            label3.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(731, 53);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 10;
            label4.Text = "Tax";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 149);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 11;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(731, 149);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 12;
            label6.Text = "Website";
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(1110, 61);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(147, 42);
            btnAddSupplier.TabIndex = 13;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Location = new Point(1110, 190);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(147, 42);
            btnDeleteSupplier.TabIndex = 14;
            btnDeleteSupplier.Text = "Delete Supplier";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.Location = new Point(1110, 127);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(147, 42);
            btnUpdateSupplier.TabIndex = 15;
            btnUpdateSupplier.Text = "Update Supplier";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 504);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(btnAddSupplier);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSupplierEmail);
            Controls.Add(txtSupplierTax);
            Controls.Add(txtSupplierWebsite);
            Controls.Add(txtSupplierMobile);
            Controls.Add(txtSupplierPhone);
            Controls.Add(txtSupplierName);
            Controls.Add(dgvSupplier);
            Name = "SupplierForm";
            Text = "SupplierForm";
            Load += SupplierForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSupplier;
        private TextBox txtSupplierName;
        private TextBox txtSupplierPhone;
        private TextBox txtSupplierMobile;
        private TextBox txtSupplierWebsite;
        private TextBox txtSupplierTax;
        private TextBox txtSupplierEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnAddSupplier;
        private Button btnDeleteSupplier;
        private Button btnUpdateSupplier;
    }
}