namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class ItemsCloseToExpirationReport
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
            nudDaysThreshold = new NumericUpDown();
            label1 = new Label();
            btnGenerateReport = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDaysThreshold).BeginInit();
            SuspendLayout();
            // 
            // nudDaysThreshold
            // 
            nudDaysThreshold.Location = new Point(650, 196);
            nudDaysThreshold.Name = "nudDaysThreshold";
            nudDaysThreshold.Size = new Size(150, 27);
            nudDaysThreshold.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(503, 198);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "Days Threshold";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(593, 321);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(134, 46);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // ItemsCloseToExpirationReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 525);
            Controls.Add(btnGenerateReport);
            Controls.Add(label1);
            Controls.Add(nudDaysThreshold);
            Name = "ItemsCloseToExpirationReport";
            Text = "ItemsCloseToExpirationReport";
            ((System.ComponentModel.ISupportInitialize)nudDaysThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudDaysThreshold;
        private Label label1;
        private Button btnGenerateReport;
    }
}