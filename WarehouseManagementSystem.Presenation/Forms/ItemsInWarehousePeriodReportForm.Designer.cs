namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class ItemsInWarehousePeriodReportForm
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
            cmbWarehouses = new ComboBox();
            label1 = new Label();
            btnGenerateReport = new Button();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // cmbWarehouses
            // 
            cmbWarehouses.FormattingEnabled = true;
            cmbWarehouses.Location = new Point(163, 188);
            cmbWarehouses.Name = "cmbWarehouses";
            cmbWarehouses.Size = new Size(265, 28);
            cmbWarehouses.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 150);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 1;
            label1.Text = "Select warehouse";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(609, 327);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(114, 41);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(510, 188);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(284, 27);
            dtpFromDate.TabIndex = 3;
            // 
            // dtpToDate
            // 
            dtpToDate.Location = new Point(934, 189);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(266, 27);
            dtpToDate.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(934, 150);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 5;
            label2.Text = "End period date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(510, 150);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 6;
            label3.Text = "Start period date";
            // 
            // ItemsInWarehousePeriodReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 491);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpToDate);
            Controls.Add(dtpFromDate);
            Controls.Add(btnGenerateReport);
            Controls.Add(label1);
            Controls.Add(cmbWarehouses);
            Name = "ItemsInWarehousePeriodReportForm";
            Text = "ItemsInWarehousePeriodReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbWarehouses;
        private Label label1;
        private Button btnGenerateReport;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Label label2;
        private Label label3;
    }
}