namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    partial class RecieptSched
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieptSched));
            this.RVSchedulePayment = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RVSchedulePayment
            // 
            this.RVSchedulePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RVSchedulePayment.Location = new System.Drawing.Point(0, 0);
            this.RVSchedulePayment.Name = "RVSchedulePayment";
            this.RVSchedulePayment.ServerReport.BearerToken = null;
            this.RVSchedulePayment.Size = new System.Drawing.Size(936, 450);
            this.RVSchedulePayment.TabIndex = 0;
            // 
            // RecieptSched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.RVSchedulePayment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecieptSched";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido Online Tutoring Management System";
            this.Load += new System.EventHandler(this.RecieptSched_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVSchedulePayment;
    }
}