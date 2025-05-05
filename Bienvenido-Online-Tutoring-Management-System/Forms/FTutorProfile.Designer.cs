namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    partial class FTutorProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTutorProfile));
            this.DGVTutor = new Guna.UI2.WinForms.Guna2DataGridView();
            this.G2BtnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.G2BtnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.G2TxbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.mTutorProfileBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._TutorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TutorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Expertise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._AvailabilityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HourlyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DaysAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTutorProfileBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVTutor
            // 
            this.DGVTutor.AllowUserToAddRows = false;
            this.DGVTutor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVTutor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTutor.AutoGenerateColumns = false;
            this.DGVTutor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.DGVTutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVTutor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTutor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVTutor.ColumnHeadersHeight = 35;
            this.DGVTutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVTutor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._TutorID,
            this.TutorName,
            this._Expertise,
            this._AvailabilityID,
            this._StartTime,
            this._EndTime,
            this._HourlyRate,
            this._DaysAvailable,
            this._Firstname,
            this._lastname});
            this.DGVTutor.DataSource = this.mTutorProfileBindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVTutor.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVTutor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.Location = new System.Drawing.Point(23, 58);
            this.DGVTutor.Margin = new System.Windows.Forms.Padding(4);
            this.DGVTutor.Name = "DGVTutor";
            this.DGVTutor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTutor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVTutor.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVTutor.Size = new System.Drawing.Size(1129, 418);
            this.DGVTutor.TabIndex = 234;
            this.DGVTutor.TabStop = false;
            this.DGVTutor.Tag = "book_id";
            this.DGVTutor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVTutor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.DGVTutor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVTutor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVTutor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVTutor.ThemeStyle.HeaderStyle.Height = 35;
            this.DGVTutor.ThemeStyle.ReadOnly = true;
            this.DGVTutor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVTutor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVTutor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.ThemeStyle.RowsStyle.Height = 22;
            this.DGVTutor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(184)))), ((int)(((byte)(177)))));
            this.DGVTutor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.DGVTutor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTutor_CellClick);
            this.DGVTutor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTutor_CellContentDoubleClick);
            // 
            // G2BtnUpdate
            // 
            this.G2BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.G2BtnUpdate.BorderRadius = 15;
            this.G2BtnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G2BtnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnUpdate.Location = new System.Drawing.Point(843, 483);
            this.G2BtnUpdate.Name = "G2BtnUpdate";
            this.G2BtnUpdate.Size = new System.Drawing.Size(152, 36);
            this.G2BtnUpdate.TabIndex = 515;
            this.G2BtnUpdate.Text = "Add";
            this.G2BtnUpdate.Click += new System.EventHandler(this.G2BtnUpdate_Click);
            // 
            // G2BtnEdit
            // 
            this.G2BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.G2BtnEdit.BorderRadius = 15;
            this.G2BtnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.G2BtnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.G2BtnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.G2BtnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2BtnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G2BtnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2BtnEdit.Location = new System.Drawing.Point(1001, 483);
            this.G2BtnEdit.Name = "G2BtnEdit";
            this.G2BtnEdit.Size = new System.Drawing.Size(152, 36);
            this.G2BtnEdit.TabIndex = 516;
            this.G2BtnEdit.Text = "Edit";
            this.G2BtnEdit.Click += new System.EventHandler(this.G2BtnEdit_Click);
            // 
            // G2TxbxSearch
            // 
            this.G2TxbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.G2TxbxSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2TxbxSearch.BorderThickness = 2;
            this.G2TxbxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.G2TxbxSearch.DefaultText = "";
            this.G2TxbxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.G2TxbxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.G2TxbxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.G2TxbxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.G2TxbxSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.G2TxbxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.G2TxbxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.G2TxbxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(68)))));
            this.G2TxbxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.G2TxbxSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("G2TxbxSearch.IconLeft")));
            this.G2TxbxSearch.Location = new System.Drawing.Point(24, 14);
            this.G2TxbxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.G2TxbxSearch.Name = "G2TxbxSearch";
            this.G2TxbxSearch.PlaceholderText = "";
            this.G2TxbxSearch.SelectedText = "";
            this.G2TxbxSearch.Size = new System.Drawing.Size(1129, 36);
            this.G2TxbxSearch.TabIndex = 517;
            this.G2TxbxSearch.TextChanged += new System.EventHandler(this.G2TxbxSearch_TextChanged);
            // 
            // mTutorProfileBindingSource1
            // 
            this.mTutorProfileBindingSource1.DataSource = typeof(Bienvenido_Online_Tutoring_Management_System.Model.MTutorProfile);
            // 
            // _TutorID
            // 
            this._TutorID.DataPropertyName = "TutorID";
            this._TutorID.HeaderText = "TutorID";
            this._TutorID.Name = "_TutorID";
            this._TutorID.ReadOnly = true;
            this._TutorID.Visible = false;
            // 
            // TutorName
            // 
            this.TutorName.DataPropertyName = "TutorName";
            this.TutorName.HeaderText = "Tutor Name";
            this.TutorName.Name = "TutorName";
            this.TutorName.ReadOnly = true;
            // 
            // _Expertise
            // 
            this._Expertise.DataPropertyName = "Expertise";
            this._Expertise.HeaderText = "Expertise";
            this._Expertise.Name = "_Expertise";
            this._Expertise.ReadOnly = true;
            // 
            // _AvailabilityID
            // 
            this._AvailabilityID.DataPropertyName = "AvailabilityID";
            this._AvailabilityID.HeaderText = "AvailabilityID";
            this._AvailabilityID.Name = "_AvailabilityID";
            this._AvailabilityID.ReadOnly = true;
            this._AvailabilityID.Visible = false;
            // 
            // _StartTime
            // 
            this._StartTime.DataPropertyName = "StartTime";
            this._StartTime.HeaderText = "Start Time";
            this._StartTime.Name = "_StartTime";
            this._StartTime.ReadOnly = true;
            // 
            // _EndTime
            // 
            this._EndTime.DataPropertyName = "EndTime";
            this._EndTime.HeaderText = "End Time";
            this._EndTime.Name = "_EndTime";
            this._EndTime.ReadOnly = true;
            // 
            // _HourlyRate
            // 
            this._HourlyRate.DataPropertyName = "HourlyRate";
            this._HourlyRate.HeaderText = "Hourly Rate";
            this._HourlyRate.Name = "_HourlyRate";
            this._HourlyRate.ReadOnly = true;
            // 
            // _DaysAvailable
            // 
            this._DaysAvailable.DataPropertyName = "DaysAvailable";
            this._DaysAvailable.HeaderText = "Days Available";
            this._DaysAvailable.Name = "_DaysAvailable";
            this._DaysAvailable.ReadOnly = true;
            // 
            // _Firstname
            // 
            this._Firstname.DataPropertyName = "Firstname";
            this._Firstname.HeaderText = "Firstname";
            this._Firstname.Name = "_Firstname";
            this._Firstname.ReadOnly = true;
            this._Firstname.Visible = false;
            // 
            // _lastname
            // 
            this._lastname.DataPropertyName = "lastname";
            this._lastname.HeaderText = "lastname";
            this._lastname.Name = "_lastname";
            this._lastname.ReadOnly = true;
            this._lastname.Visible = false;
            // 
            // FTutorProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1166, 532);
            this.Controls.Add(this.G2TxbxSearch);
            this.Controls.Add(this.G2BtnEdit);
            this.Controls.Add(this.G2BtnUpdate);
            this.Controls.Add(this.DGVTutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FTutorProfile";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "FTutorProfile";
            this.Load += new System.EventHandler(this.FTutorProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTutorProfileBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DGVTutor;
        private Guna.UI2.WinForms.Guna2Button G2BtnUpdate;
        private Guna.UI2.WinForms.Guna2Button G2BtnEdit;
        private Guna.UI2.WinForms.Guna2TextBox G2TxbxSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn TutorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expertise;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourlyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailabilityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.BindingSource mTutorProfileBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TutorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TutorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Expertise;
        private System.Windows.Forms.DataGridViewTextBoxColumn _AvailabilityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn _EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HourlyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _DaysAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _lastname;
    }
}