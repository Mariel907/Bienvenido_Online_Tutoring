using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        private BindingSource bindingSource = new BindingSource();
        private DateTime SDate;
        private DateTime EDate;
        public FEarningsTutor(MTutorProfile mt)
        {
            InitializeComponent();
            this.mt = mt;

        }
        private void FillInFields()
        {
            G2CmbxTutorName.Text = mt.TutorName;
        }
        private void DgvBinding()
        {
            bindingSource.DataSource = CEarnings.TutorSched(LblID.Text);
        }

        private void FEarningsTutor_Load(object sender, EventArgs e)
        {
            TutorName();
            FillInFields();
            transaction.UpdateStatus(DGV);
            DgvBinding();
            //ShowDGV();
            G2CHKScheduled.Checked = true;
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
                StatusChecked();
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
        private void StatusChecked()
        {
            string Lbl = LblID.Text;
            List<string> Checked = new List<string>();

            if (G2CHKDone.Checked) Checked.Add("Done");
            if (G2CHKScheduled.Checked) Checked.Add("Scheduled");
            if (G2CHKOnGoing.Checked) Checked.Add("OnGoing");

            earnings.SearchCmbx(DGV, Lbl, Checked);
        }

        private void CHKChecked_CheckedChanged(object sender, EventArgs e)
        {
            StatusChecked();
        }

        private void Fetch(DateTime SDate, DateTime EDate)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is EFTrackingEarnings) return;
            }
            MTutorProfile mt = new MTutorProfile();
            mt.SDate = SDate;
            mt.EDate = EDate;
            mt.TutorID = Convert.ToInt32(LblID.Text);
            mt.TutorName = G2CmbxTutorName.Text;

            EFTrackingEarnings eFTrackingEarnings = new EFTrackingEarnings(mt);
            eFTrackingEarnings.Show();
        }

        private void MonthlyEarnings_Click(object sender, EventArgs e)
        {
            SDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            EDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            Fetch(SDate, EDate);
        }

        private void PostMonthEarnings_Click(object sender, EventArgs e)
        {
            SDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            EDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
            Fetch(SDate, EDate);
        }

        private void ThisYearEarnings_Click(object sender, EventArgs e)
        {
            SDate = new DateTime(DateTime.Now.Year, 1, 1);
            EDate = new DateTime(DateTime.Now.Year, 12, 31);
            Fetch(SDate, EDate);
        }

        private void LastYearEarnings_Click(object sender, EventArgs e)
        {
            SDate = new DateTime(DateTime.Now.Year -1, 1, 1);
            EDate = new DateTime(DateTime.Now.Year - 1, 12, 31);
            Fetch(SDate,EDate);
        }

        private void WeeklyEarnings_Click(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Now;
            DayOfWeek firstDayofWeek = DayOfWeek.Monday;
            SDate = Today.AddDays(-(int)Today.DayOfWeek + (int)firstDayofWeek);
            EDate = SDate.AddDays(6);
            Fetch(SDate, EDate);
        }

        private void DailyEarnings_Click(object sender, EventArgs e)
        {
            SDate = DateTime.Now;
            EDate = DateTime.Now;
            Fetch(SDate, EDate);
        }
    }
}
