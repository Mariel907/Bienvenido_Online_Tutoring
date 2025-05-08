namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    partial class ListSessionsCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstSessions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstSessions
            // 
            this.lstSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.lstSessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSessions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSessions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.IntegralHeight = false;
            this.lstSessions.ItemHeight = 17;
            this.lstSessions.Location = new System.Drawing.Point(0, 0);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(166, 149);
            this.lstSessions.TabIndex = 3;
            this.lstSessions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSessions_MouseMove);
            // 
            // ListSessionsCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lstSessions);
            this.Name = "ListSessionsCalendar";
            this.Size = new System.Drawing.Size(166, 149);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSessions;
    }
}
