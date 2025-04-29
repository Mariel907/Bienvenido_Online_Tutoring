namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.G2Subjects = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnPayments = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnStudents = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnTutorsProfile = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlDashboard = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.G2Subjects);
            this.panel1.Controls.Add(this.G2BtnPayments);
            this.panel1.Controls.Add(this.G2BtnTransaction);
            this.panel1.Controls.Add(this.G2BtnStudents);
            this.panel1.Controls.Add(this.G2BtnTutorsProfile);
            this.panel1.Controls.Add(this.G2BtnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(184, 681);
            this.panel1.TabIndex = 0;
            // 
            // G2Subjects
            // 
            this.G2Subjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2Subjects.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2Subjects.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2Subjects.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2Subjects.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2Subjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2Subjects.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2Subjects.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2Subjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2Subjects.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Subjects_Bien;
            this.G2Subjects.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2Subjects.Location = new System.Drawing.Point(10, 405);
            this.G2Subjects.Name = "G2Subjects";
            this.G2Subjects.Size = new System.Drawing.Size(164, 45);
            this.G2Subjects.TabIndex = 6;
            this.G2Subjects.Text = "Subjects";
            this.G2Subjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2Subjects.Click += new System.EventHandler(this.Form_Click);
            // 
            // G2BtnPayments
            // 
            this.G2BtnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2BtnPayments.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnPayments.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnPayments.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnPayments.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnPayments.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2BtnPayments.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2BtnPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnPayments.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Payment_Bien;
            this.G2BtnPayments.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnPayments.Location = new System.Drawing.Point(10, 360);
            this.G2BtnPayments.Name = "G2BtnPayments";
            this.G2BtnPayments.Size = new System.Drawing.Size(164, 45);
            this.G2BtnPayments.TabIndex = 5;
            this.G2BtnPayments.Text = "Payments";
            this.G2BtnPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnPayments.Click += new System.EventHandler(this.Form_Click);
            // 
            // G2BtnTransaction
            // 
            this.G2BtnTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2BtnTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2BtnTransaction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnTransaction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2BtnTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnTransaction.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Transaction_Bien;
            this.G2BtnTransaction.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnTransaction.Location = new System.Drawing.Point(10, 315);
            this.G2BtnTransaction.Name = "G2BtnTransaction";
            this.G2BtnTransaction.Size = new System.Drawing.Size(164, 45);
            this.G2BtnTransaction.TabIndex = 4;
            this.G2BtnTransaction.Text = "Transactions";
            this.G2BtnTransaction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnTransaction.Click += new System.EventHandler(this.Form_Click);
            // 
            // G2BtnStudents
            // 
            this.G2BtnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2BtnStudents.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnStudents.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnStudents.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnStudents.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2BtnStudents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2BtnStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnStudents.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Student;
            this.G2BtnStudents.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnStudents.Location = new System.Drawing.Point(10, 270);
            this.G2BtnStudents.Name = "G2BtnStudents";
            this.G2BtnStudents.Size = new System.Drawing.Size(164, 45);
            this.G2BtnStudents.TabIndex = 3;
            this.G2BtnStudents.Text = "Students";
            this.G2BtnStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnStudents.Click += new System.EventHandler(this.Form_Click);
            // 
            // G2BtnTutorsProfile
            // 
            this.G2BtnTutorsProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2BtnTutorsProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnTutorsProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnTutorsProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnTutorsProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnTutorsProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2BtnTutorsProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnTutorsProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2BtnTutorsProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnTutorsProfile.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Tutor_Profile;
            this.G2BtnTutorsProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnTutorsProfile.Location = new System.Drawing.Point(10, 225);
            this.G2BtnTutorsProfile.Name = "G2BtnTutorsProfile";
            this.G2BtnTutorsProfile.Size = new System.Drawing.Size(164, 45);
            this.G2BtnTutorsProfile.TabIndex = 2;
            this.G2BtnTutorsProfile.Text = "Tutors Profile";
            this.G2BtnTutorsProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnTutorsProfile.Click += new System.EventHandler(this.Form_Click);
            // 
            // G2BtnDashboard
            // 
            this.G2BtnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(241)))));
            this.G2BtnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.G2BtnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.G2BtnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.G2BtnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnDashboard.Image = global::Bienvenido_Online_Tutoring_Management_System.Properties.Resources.Dashboard_Bien;
            this.G2BtnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnDashboard.Location = new System.Drawing.Point(10, 180);
            this.G2BtnDashboard.Name = "G2BtnDashboard";
            this.G2BtnDashboard.Size = new System.Drawing.Size(164, 45);
            this.G2BtnDashboard.TabIndex = 0;
            this.G2BtnDashboard.Text = "Dashboard";
            this.G2BtnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.G2BtnDashboard.Click += new System.EventHandler(this.Form_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(164, 170);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.Form_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(184, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(1166, 86);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1146, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido Online Tutoring";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1146, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Management System ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel4.Controls.Add(this.LblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(184, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1166, 49);
            this.panel4.TabIndex = 2;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.LblTitle.Location = new System.Drawing.Point(0, -1);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1166, 50);
            this.LblTitle.TabIndex = 2;
            this.LblTitle.Text = "Dashboard";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlDashboard
            // 
            this.PnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDashboard.Location = new System.Drawing.Point(184, 135);
            this.PnlDashboard.Name = "PnlDashboard";
            this.PnlDashboard.Size = new System.Drawing.Size(1166, 546);
            this.PnlDashboard.TabIndex = 3;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1350, 681);
            this.Controls.Add(this.PnlDashboard);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido Online Tutoring Management System";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button G2BtnDashboard;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button G2BtnPayments;
        private Guna.UI2.WinForms.Guna2Button G2BtnTransaction;
        private Guna.UI2.WinForms.Guna2Button G2BtnStudents;
        private Guna.UI2.WinForms.Guna2Button G2BtnTutorsProfile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PnlDashboard;
        private Guna.UI2.WinForms.Guna2Button G2Subjects;
    }
}