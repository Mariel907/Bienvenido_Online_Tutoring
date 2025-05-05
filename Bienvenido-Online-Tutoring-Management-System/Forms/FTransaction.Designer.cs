namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    partial class FTransaction
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTransaction));
            this.DGVScheduled = new Guna.UI2.WinForms.Guna2DataGridView();
            this.G2BtnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.G2CmbxStudentName = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SessionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TutorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tutorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourlyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mSessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduled)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSessionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVScheduled
            // 
            this.DGVScheduled.AllowUserToAddRows = false;
            this.DGVScheduled.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVScheduled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVScheduled.AutoGenerateColumns = false;
            this.DGVScheduled.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.DGVScheduled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVScheduled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVScheduled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVScheduled.ColumnHeadersHeight = 35;
            this.DGVScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVScheduled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SessionID,
            this.TutorID,
            this.StudName,
            this.tutorNameDataGridViewTextBoxColumn,
            this.Subject,
            this.StudentID,
            this.StartTime,
            this.EndTime,
            this.SessionDate,
            this.TotalAmount,
            this.HourlyRate,
            this.Status,
            this.StatusBill,
            this.InvoiceID,
            this.TotalHours});
            this.DGVScheduled.DataSource = this.mSessionBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVScheduled.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVScheduled.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.Location = new System.Drawing.Point(13, 87);
            this.DGVScheduled.Margin = new System.Windows.Forms.Padding(4);
            this.DGVScheduled.Name = "DGVScheduled";
            this.DGVScheduled.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVScheduled.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVScheduled.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVScheduled.Size = new System.Drawing.Size(1140, 390);
            this.DGVScheduled.TabIndex = 236;
            this.DGVScheduled.TabStop = false;
            this.DGVScheduled.Tag = "book_id";
            this.DGVScheduled.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVScheduled.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.DGVScheduled.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVScheduled.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVScheduled.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVScheduled.ThemeStyle.HeaderStyle.Height = 35;
            this.DGVScheduled.ThemeStyle.ReadOnly = true;
            this.DGVScheduled.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVScheduled.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVScheduled.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.ThemeStyle.RowsStyle.Height = 22;
            this.DGVScheduled.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVScheduled.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVScheduled.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVScheduled_CellFormatting);
            // 
            // G2BtnSchedule
            // 
            this.G2BtnSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.G2BtnSchedule.BorderRadius = 15;
            this.G2BtnSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnSchedule.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnSchedule.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G2BtnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnSchedule.Location = new System.Drawing.Point(1001, 484);
            this.G2BtnSchedule.Name = "G2BtnSchedule";
            this.G2BtnSchedule.Size = new System.Drawing.Size(152, 36);
            this.G2BtnSchedule.TabIndex = 519;
            this.G2BtnSchedule.Text = "Add Schedule";
            this.G2BtnSchedule.Click += new System.EventHandler(this.G2BtnSchedule_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 21);
            this.label5.TabIndex = 567;
            this.label5.Text = "Student Name";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Location = new System.Drawing.Point(193, 43);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(4, 36);
            this.panel16.TabIndex = 576;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel17.Location = new System.Drawing.Point(0, -10);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(179, 2);
            this.panel17.TabIndex = 442;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Location = new System.Drawing.Point(18, 43);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(2, 32);
            this.panel14.TabIndex = 573;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel15.Location = new System.Drawing.Point(0, -10);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(179, 2);
            this.panel15.TabIndex = 442;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Location = new System.Drawing.Point(13, 77);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(181, 5);
            this.panel12.TabIndex = 577;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel13.Location = new System.Drawing.Point(0, -10);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(179, 2);
            this.panel13.TabIndex = 442;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(15, 44);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(176, 5);
            this.panel10.TabIndex = 574;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel11.Location = new System.Drawing.Point(0, -10);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(179, 2);
            this.panel11.TabIndex = 442;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(15, 70);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(176, 5);
            this.panel8.TabIndex = 571;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel9.Location = new System.Drawing.Point(0, -10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(179, 2);
            this.panel9.TabIndex = 442;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(191, 41);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 36);
            this.panel6.TabIndex = 575;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel7.Location = new System.Drawing.Point(0, -10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(179, 2);
            this.panel7.TabIndex = 442;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(13, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 36);
            this.panel4.TabIndex = 572;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel5.Location = new System.Drawing.Point(0, -10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(179, 2);
            this.panel5.TabIndex = 442;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel2.Location = new System.Drawing.Point(14, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 2);
            this.panel2.TabIndex = 570;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(13, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 2);
            this.panel1.TabIndex = 569;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(162)))));
            this.panel3.Location = new System.Drawing.Point(0, -10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 2);
            this.panel3.TabIndex = 442;
            // 
            // G2CmbxStudentName
            // 
            this.G2CmbxStudentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.G2CmbxStudentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.G2CmbxStudentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2CmbxStudentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.G2CmbxStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G2CmbxStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2CmbxStudentName.Location = new System.Drawing.Point(18, 45);
            this.G2CmbxStudentName.Name = "G2CmbxStudentName";
            this.G2CmbxStudentName.Size = new System.Drawing.Size(179, 35);
            this.G2CmbxStudentName.TabIndex = 568;
            this.G2CmbxStudentName.SelectedIndexChanged += new System.EventHandler(this.G2CmbxStudentName_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(845, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 578;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(982, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 579;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1110, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 580;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(792, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 21);
            this.label1.TabIndex = 581;
            this.label1.Text = "Done";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(894, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 582;
            this.label2.Text = "Scheduled";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(1031, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 583;
            this.label3.Text = "OnGoing";
            // 
            // SessionID
            // 
            this.SessionID.DataPropertyName = "SessionID";
            this.SessionID.HeaderText = "SessionID";
            this.SessionID.Name = "SessionID";
            this.SessionID.ReadOnly = true;
            this.SessionID.Visible = false;
            // 
            // TutorID
            // 
            this.TutorID.DataPropertyName = "TutorID";
            this.TutorID.HeaderText = "TutorID";
            this.TutorID.Name = "TutorID";
            this.TutorID.ReadOnly = true;
            this.TutorID.Visible = false;
            // 
            // StudName
            // 
            this.StudName.DataPropertyName = "StudName";
            this.StudName.HeaderText = "Student Name";
            this.StudName.Name = "StudName";
            this.StudName.ReadOnly = true;
            // 
            // tutorNameDataGridViewTextBoxColumn
            // 
            this.tutorNameDataGridViewTextBoxColumn.DataPropertyName = "TutorName";
            this.tutorNameDataGridViewTextBoxColumn.HeaderText = "Tutor Name";
            this.tutorNameDataGridViewTextBoxColumn.Name = "tutorNameDataGridViewTextBoxColumn";
            this.tutorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Visible = false;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // SessionDate
            // 
            this.SessionDate.DataPropertyName = "SessionDate";
            this.SessionDate.HeaderText = "Session Date";
            this.SessionDate.Name = "SessionDate";
            this.SessionDate.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Visible = false;
            // 
            // HourlyRate
            // 
            this.HourlyRate.DataPropertyName = "HourlyRate";
            this.HourlyRate.HeaderText = "HourlyRate";
            this.HourlyRate.Name = "HourlyRate";
            this.HourlyRate.ReadOnly = true;
            this.HourlyRate.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // StatusBill
            // 
            this.StatusBill.DataPropertyName = "StatusBill";
            this.StatusBill.HeaderText = "StatusBill";
            this.StatusBill.Name = "StatusBill";
            this.StatusBill.ReadOnly = true;
            this.StatusBill.Visible = false;
            // 
            // InvoiceID
            // 
            this.InvoiceID.DataPropertyName = "InvoiceID";
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.Visible = false;
            // 
            // TotalHours
            // 
            this.TotalHours.DataPropertyName = "TotalHours";
            this.TotalHours.HeaderText = "TotalHours";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.Visible = false;
            // 
            // mSessionBindingSource
            // 
            this.mSessionBindingSource.DataSource = typeof(Bienvenido_Online_Tutoring_Management_System.Model.MSession);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.LblID.Location = new System.Drawing.Point(115, 17);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(19, 21);
            this.LblID.TabIndex = 584;
            this.LblID.Text = "0";
            // 
            // FTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1166, 532);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.G2CmbxStudentName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.G2BtnSchedule);
            this.Controls.Add(this.DGVScheduled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FTransaction";
            this.Text = "FTransaction";
            this.Load += new System.EventHandler(this.FTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduled)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSessionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DGVScheduled;
        private Guna.UI2.WinForms.Guna2Button G2BtnSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudFullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn TutorFullname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox G2CmbxStudentName;
        private System.Windows.Forms.BindingSource mSessionBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TutorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourlyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.Label LblID;
    }
}