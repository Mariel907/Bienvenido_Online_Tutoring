using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class FEarningsTutor : Form
    {
        private MTutorProfile mt;
        private CEarnings earnings = new CEarnings();
        private CTransaction transaction = new CTransaction();
        public FEarningsTutor(MTutorProfile mt)
        {
            InitializeComponent();
            this.mt = mt;

        }
        private void FillInFields()
        {
            G2CmbxTutorName.Text = mt.TutorName;
        }

        private void FEarningsTutor_Load(object sender, EventArgs e)
        {
            TutorName();
            FillInFields();
            transaction.UpdateStatus(DGV);
        }
        private void TutorName()
        {
            G2CmbxTutorName.DataSource = CEarnings.TutorShow();
            G2CmbxTutorName.DisplayMember = "TutorName";
            G2CmbxTutorName.ValueMember = "TutorID";
        }
        private void ShowDGV()
        {
            earnings.ShowDgvSched(LblID.Text, DGV);
        }

        private void G2CmbxTutorName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (G2CmbxTutorName.SelectedValue != null)
            {
                MTutorProfile mt = G2CmbxTutorName.SelectedItem as MTutorProfile;
                LblID.Text = mt.TutorID.ToString();
                ShowDGV();
            }
            UpdateLbl();
        }

        private void UpdateLbl()
        {
            string update = string.Empty;
            string LblId = LblID.Text;  
            earnings.Earnings(ref update, "MontlyEarnings", LblId);
            LblMontlyEarnings.Text = update;

            earnings.Earnings(ref update, "DailyEarnings", LblId);
            LblDailyEarnings.Text = update;

            earnings.Earnings(ref update, "WeeklyEarnings", LblId);
            LblWeeklyEarnings.Text = update;

            earnings.Earnings(ref update, "LastMonthEarnings", LblId);
            LblLastMonth.Text = update;

            earnings.Earnings(ref update, "ThisYearEarnings", LblId);
            LblThisYear.Text = update;

            earnings.Earnings(ref update, "LastYearEarnings", LblId);
            LblLastYear.Text = update;  
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = DGV.Rows[e.RowIndex];
            string Status = row.Cells["Status"].Value?.ToString();

            switch(Status)
            {
                case "Scheduled":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                    break;
                case "OnGoing":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153);
                    break;
                case "Done":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                    break;
            }
        }

        private void G2CmbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchStatus();
        }
        private void SearchStatus()
        {
            string Cmbx = G2CmbxStatus.Text;
            string Lbl = LblID.Text;
            if (Cmbx == "All")
                ShowDGV();
            else
                earnings.SearchCmbx(DGV, Lbl);

        }
    }
}
