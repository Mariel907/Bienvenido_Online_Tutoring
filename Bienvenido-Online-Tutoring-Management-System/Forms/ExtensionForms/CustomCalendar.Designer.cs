﻿namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    partial class CustomCalendar
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
            this.LblDay = new System.Windows.Forms.Label();
            this.lstSessions = new System.Windows.Forms.ListBox();
            this.Lblweather = new System.Windows.Forms.Label();
            this.Pctr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pctr)).BeginInit();
            this.SuspendLayout();
            // 
            // LblDay
            // 
            this.LblDay.AutoSize = true;
            this.LblDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblDay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.LblDay.Location = new System.Drawing.Point(0, 0);
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(25, 19);
            this.LblDay.TabIndex = 510;
            this.LblDay.Text = "10";
            // 
            // lstSessions
            // 
            this.lstSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.lstSessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSessions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSessions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstSessions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSessions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.IntegralHeight = false;
            this.lstSessions.ItemHeight = 17;
            this.lstSessions.Location = new System.Drawing.Point(0, 19);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(179, 143);
            this.lstSessions.TabIndex = 511;
            this.lstSessions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstSessions_DrawItem);
            this.lstSessions.MouseLeave += new System.EventHandler(this.lstSessions_MouseLeave);
            this.lstSessions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSessions_MouseMove);
            // 
            // Lblweather
            // 
            this.Lblweather.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblweather.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.Lblweather.Location = new System.Drawing.Point(51, 0);
            this.Lblweather.Name = "Lblweather";
            this.Lblweather.Size = new System.Drawing.Size(62, 19);
            this.Lblweather.TabIndex = 512;
            this.Lblweather.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pctr
            // 
            this.Pctr.Location = new System.Drawing.Point(24, -1);
            this.Pctr.Name = "Pctr";
            this.Pctr.Size = new System.Drawing.Size(31, 21);
            this.Pctr.TabIndex = 513;
            this.Pctr.TabStop = false;
            // 
            // CustomCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.Pctr);
            this.Controls.Add(this.lstSessions);
            this.Controls.Add(this.Lblweather);
            this.Controls.Add(this.LblDay);
            this.Name = "CustomCalendar";
            this.Size = new System.Drawing.Size(179, 162);
            ((System.ComponentModel.ISupportInitialize)(this.Pctr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDay;
        private System.Windows.Forms.ListBox lstSessions;
        private System.Windows.Forms.Label Lblweather;
        private System.Windows.Forms.PictureBox Pctr;
    }
}
