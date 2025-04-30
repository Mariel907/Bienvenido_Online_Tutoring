using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Management;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EFSChedule : Form
    {
        private MStudent student;
        private CSchedule schedule = new CSchedule();
        public EFSChedule(MStudent Stud)
        {
            InitializeComponent();
            student = Stud;
            AssignValue();
        }
        private void AssignValue()
        {
            LblStudentID.Text = student.StudentID.ToString();
            G2TxbxFullname.Text = student.Fullname;
        }
        private void EFSChedule_Load(object sender, EventArgs e)
        {
            PrefferedSubject();
            TutorExprtise();
            AVDay();
        }

        private void PrefferedSubject()
        {
            G2CmbxPreferredSubjects.DataSource = CSchedule.PreferredSubjects(LblStudentID.Text);
            G2CmbxPreferredSubjects.DisplayMember = "SubjectName";
            G2CmbxPreferredSubjects.ValueMember = "StudentID";
        }

        private void TutorExprtise()
        {
            G2CmbxTutorName.DataSource = CSchedule.TutorExpertise(G2CmbxPreferredSubjects.Text);
            G2CmbxTutorName.DisplayMember = "Fullname";
            G2CmbxTutorName.ValueMember = "TutorID";
        }
        private void AVDay()
        {
            G2CmbxAvailableDay.DataSource = CSchedule.AvailableDay(LblTutorID.Text);
            G2CmbxAvailableDay.DisplayMember = "DaysAvailable";
            G2CmbxAvailableDay.ValueMember = "TutorID";

        }
        private void SlotsDateAvailable()
        {
            var groupedSlots = CSchedule.GetTimeslotsByDate(LblTutorID.Text, G2CmbxAvailableDay.Text);

            G2CmbxDateAvailable.DataSource = groupedSlots.Keys
                .Select(date => date.ToShortDateString())
                .ToList();
        }
        private void DGVStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void G2CmbxTutorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G2CmbxTutorName.SelectedValue != null)
            {
                MTutorProfile tutor = G2CmbxTutorName.SelectedItem as MTutorProfile;
                LblTutorID.Text = tutor.TutorID.ToString();
                G2TxbxHourlyRate.Text = tutor.HourlyRate.ToString();
            }
            AVDay();
        }

        private void G2CmbxAvailableDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotsDateAvailable();
        }

        private void G2CmbxDateAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(G2CmbxDateAvailable.SelectedItem.ToString(), out DateTime selectedDate))
            {
                var groupedSlots = CSchedule.GetTimeslotsByDate(LblTutorID.Text, G2CmbxAvailableDay.Text);

                if (groupedSlots.TryGetValue(selectedDate, out List<TimeSpan> timeslots))
                {
                    G2CmbxStartTime.DataSource = new List<TimeSpan>(timeslots);
                    G2CmbxStartTime.DisplayMember = "ToString";
                    G2CmbxEndTime.DataSource = new List<TimeSpan>(timeslots);
                    G2CmbxEndTime.DisplayMember = "ToString";
                }
                else
                {
                    G2CmbxStartTime.DataSource = null;
                    G2CmbxEndTime.DataSource = null;
                }
            }
            else
                MessageBox.Show("Invalid date selected.", "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            MSubjects sub = G2CmbxPreferredSubjects.SelectedItem as MSubjects;
            MTutorProfile tutor = G2CmbxTutorName.SelectedItem as MTutorProfile;
            string Result = string.Empty;
            try
            {
                if(ValidateStartAndEndTime()) return;
                validationSched();
                TimeSpan STime = (TimeSpan) G2CmbxStartTime.SelectedValue;
                TimeSpan ETime = (TimeSpan) G2CmbxEndTime.SelectedValue;

                DateTime selectedDate = Convert.ToDateTime(G2CmbxDateAvailable.SelectedItem);
                DateTime Startdate = selectedDate.Add(STime);
                DateTime EndTime = selectedDate.Add(ETime);

                int sessionID = CAutoIncrementID.NextSessionID();
                int InvoiceID = CAutoIncrementID.NextInvoiceID();
                decimal totalHours = (decimal)(EndTime - Startdate).TotalHours;
                decimal totalAmount = Math.Round(totalHours * tutor.HourlyRate, 2);

                int rowIndex = DGVStudent.Rows.Add();
                DataGridViewRow row = DGVStudent.Rows[rowIndex];
                row.Cells["SessionID"].Value = sessionID;
                row.Cells["TutorID"].Value = tutor.TutorID;
                row.Cells["TutorName"].Value = tutor.Fullname;
                row.Cells["Subject"].Value = sub.SubjectName;
                row.Cells["StartTime"].Value = STime;
                row.Cells["EndTime"].Value = ETime;
                row.Cells["HourlyRate"].Value = tutor.HourlyRate;
                row.Cells["TotalAmount"].Value = totalAmount;
                row.Cells["SessionDate"].Value = G2CmbxDateAvailable.SelectedValue;
                row.Cells["TotalHours"].Value = totalHours;
                row.Cells["InvoiceID"].Value = InvoiceID;

                schedule.Insert(sub, tutor, LblStudentID.Text, STime, ETime, G2CmbxDateAvailable.SelectedValue, totalAmount, InvoiceID);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 16)
                    Result = ex.Message;
                else
                    MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string total = string.Empty;
            schedule.UpdateTotal(DGVStudent, ref total);
            LblGrandTotal.Text = total;

            SlotsDateAvailable();
        }
        
        private void validationSched()
        {
            MSession session = new MSession();
            session.StartTime = (TimeSpan) G2CmbxStartTime.SelectedValue;
            session.EndTime = (TimeSpan) G2CmbxEndTime.SelectedValue;
            session.SessionDate = Convert.ToDateTime(G2CmbxDateAvailable.SelectedValue);
            session.TutorID = Convert.ToInt32(LblTutorID.Text);
            session.StudentID = Convert.ToInt32(LblStudentID.Text);
            schedule.Validation(session);
        }

        private bool ValidateStartAndEndTime()
        {
            TimeSpan STime = (TimeSpan)G2CmbxStartTime.SelectedValue;
            TimeSpan ETime = (TimeSpan)G2CmbxEndTime.SelectedValue;

            if (STime == ETime || ETime < STime)
            {
                MessageBox.Show("Start time and End time must not be equal", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if(ETime < STime)
            {
                MessageBox.Show("End time must not be less than the start time ", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
                return false;
        }

        private void G2CmbxPreferredSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            TutorExprtise();
        }

        private void G2BtnVoid_Click(object sender, EventArgs e)
        {
            schedule.Void(DGVStudent);

            string GrandTotal = LblGrandTotal.Text;
            string UpdateGrandTotal = string.Empty;
            schedule.SubtractCancel(DGVStudent, GrandTotal, ref UpdateGrandTotal );

            LblGrandTotal.Text = UpdateGrandTotal;

            SlotsDateAvailable();
        }

        private void guna2TextBoxCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private bool IsSufficientCash()
        {
            decimal cash = Convert.ToDecimal(guna2TextBoxCash.Text);
            decimal TotalAmount = Convert.ToDecimal(LblGrandTotal.Text.Replace("P", "").Trim());

            if (cash < TotalAmount)
            {
                MessageBox.Show("Insufficient cash amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void guna2TextBoxCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                if (IsSufficientCash()) return;

                decimal cash = Convert.ToDecimal(guna2TextBoxCash.Text);
                decimal TotalAmount = Convert.ToDecimal(LblGrandTotal.Text.Replace("P", "").Trim());
                string change = string.Empty;

                schedule.CalculateChange(TotalAmount, cash, ref change);
                guna2TextBoxCash.Text = cash.ToString("N2");
                guna2TextBoxChange.Text = change;
                e.SuppressKeyPress = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void G2BtnGenerateSchedule_Click(object sender, EventArgs e)
        {
            MStudent stud = new MStudent();
            stud.StudentID = Convert.ToInt32(LblStudentID.Text);
            stud.Fullname = G2TxbxFullname.Text;
            stud.Cash = Convert.ToDecimal(guna2TextBoxCash.Text);
            stud.Changed = Convert.ToDecimal(guna2TextBoxChange.Text);

            schedule.PaidStatusBill(DGVStudent);
            schedule.FillInInvoices(DGVStudent, stud);

        }

        private void G2CmbxStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
