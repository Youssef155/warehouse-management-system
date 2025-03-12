namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class WarehousesItemsReportForm
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
            clbWarehouses = new CheckedListBox();
            label1 = new Label();
            btnGenerateReport = new Button();
            SuspendLayout();
            // 
            // clbWarehouses
            // 
            clbWarehouses.FormattingEnabled = true;
            clbWarehouses.Location = new Point(483, 153);
            clbWarehouses.Name = "clbWarehouses";
            clbWarehouses.Size = new Size(328, 114);
            clbWarehouses.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(483, 115);
            label1.Name = "label1";
            label1.Size = new Size(282, 20);
            label1.TabIndex = 1;
            label1.Text = "Check Warehouses to generate the report";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(561, 340);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(170, 39);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // WarehousesItemsReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 460);
            Controls.Add(btnGenerateReport);
            Controls.Add(label1);
            Controls.Add(clbWarehouses);
            Name = "WarehousesItemsReportForm";
            Text = "WarehousesItemsReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbWarehouses;
        private Label label1;
        private Button btnGenerateReport;
    }
}