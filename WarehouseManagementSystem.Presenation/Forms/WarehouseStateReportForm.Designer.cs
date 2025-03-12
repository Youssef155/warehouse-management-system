namespace WarehouseManagementSystem.Presenation.Forms
{
    partial class WarehouseStateReportForm
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
            comboBoxWarehouses = new ComboBox();
            label1 = new Label();
            btnGenerateReport = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxWarehouses
            // 
            comboBoxWarehouses.FormattingEnabled = true;
            comboBoxWarehouses.Location = new Point(389, 171);
            comboBoxWarehouses.Name = "comboBoxWarehouses";
            comboBoxWarehouses.Size = new Size(151, 28);
            comboBoxWarehouses.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(237, 174);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Warehouse";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(825, 165);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(203, 38);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1385, 125);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(389, 39);
            label2.Name = "label2";
            label2.Size = new Size(598, 46);
            label2.TabIndex = 0;
            label2.Text = "Warehouse Report Generator";
            // 
            // WarehouseStateReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1385, 640);
            Controls.Add(panel1);
            Controls.Add(btnGenerateReport);
            Controls.Add(label1);
            Controls.Add(comboBoxWarehouses);
            Name = "WarehouseStateReportForm";
            Text = "WarehouseStateReportForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxWarehouses;
        private Label label1;
        private Button btnGenerateReport;
        private Panel panel1;
        private Label label2;
    }
}