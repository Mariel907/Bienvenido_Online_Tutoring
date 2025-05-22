using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            G2TxbxFullname.Text = student.StudentName;
            LblEmail.Text = student.ContactDetails;
        }
        private void EFSChedule_Load(object sender, EventArgs e)
        {
            PrefferedSubject();
            TutorExprtise();
            AVDay();
            DraftValidation();
            UpdateTotallbl();
        }
        private void DraftValidation()
        {
            string Result = string.Empty;
            ShowAllSchedStudent();
            schedule.ValidationDraft(DGVStudent);
            DGVStudent.Rows.Clear();
            ShowAllSchedStudent();
        }
        private void ShowAllSchedStudent()
        {
            var ScheduledSession = CSchedule.ShowScheduled(LblStudentID.Text);

            foreach (var session in ScheduledSession)
            {
                int rowIndex = DGVStudent.Rows.Add();
                DataGridViewRow row = DGVStudent.Rows[rowIndex];
                row.Cells["SessionID"].Value = session.SessionID;
                row.Cells["TutorID"].Value = session.TutorID;
                row.Cells["TutorName"].Value = session.TutorName;
                row.Cells["Subject"].Value = session.Subject;
                row.Cells["StartTime"].Value = session.StartTime;
                row.Cells["EndTime"].Value = session.EndTime;
                row.Cells["HourlyRate"].Value = session.HourlyRate;
                row.Cells["TotalAmount"].Value = session.TotalAmount;
                row.Cells["SessionDate"].Value = session.SessionDate.ToString("MM/dd/yyyy");
                row.Cells["TotalHours"].Value = session.TotalHours;
                row.Cells["InvoiceID"].Value = session.InvoiceID;
                row.Cells["StatusBill"].Value = session.StatusBill;
                row.Cells["Status"].Value = session.Status;
                row.Cells["StudentID"].Value = session.StudentID;
                row.Cells["EmailTutor"].Value = session.Email;
            }
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
            G2CmbxTutorName.DisplayMember = "TutorName";
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
                .Select(date => date.ToString("MM/dd/yyyy"))
                .ToList();
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
                if (ValidateStartAndEndTime()) return;
                if (IsDraftSessiondateAndTimeExists())
                {
                    return;
                }

                validationSched();

                TimeSpan STime = (TimeSpan)G2CmbxStartTime.SelectedValue;
                TimeSpan ETime = (TimeSpan)G2CmbxEndTime.SelectedValue;

                DateTime selectedDate = Convert.ToDateTime(G2CmbxDateAvailable.SelectedItem);
                DateTime Startdate = selectedDate.Add(STime);
                DateTime EndTime = selectedDate.Add(ETime);

                int sessionID = CAutoIncrementID.NextSessionID();
                int InvoiceID = CAutoIncrementID.NextInvoiceID();
                decimal totalHours = (decimal)(EndTime - Startdate).TotalHours;
                string formatedTotalHours = totalHours.ToString("F2");
                decimal totalAmount = Math.Round(totalHours * tutor.HourlyRate, 2);


                int rowIndex = DGVStudent.Rows.Add();
                DataGridViewRow row = DGVStudent.Rows[rowIndex];
                row.Cells["SessionID"].Value = sessionID;
                row.Cells["TutorID"].Value = tutor.TutorID;
                row.Cells["TutorName"].Value = tutor.TutorName;
                row.Cells["Subject"].Value = sub.SubjectName;
                row.Cells["StartTime"].Value = STime;
                row.Cells["EndTime"].Value = ETime;
                row.Cells["HourlyRate"].Value = tutor.HourlyRate;
                row.Cells["TotalAmount"].Value = totalAmount;
                row.Cells["SessionDate"].Value = G2CmbxDateAvailable.SelectedValue;
                row.Cells["TotalHours"].Value = formatedTotalHours;
                row.Cells["InvoiceID"].Value = InvoiceID;
                row.Cells["StatusBill"].Value = "Pending";
                row.Cells["Status"].Value = "Draft";
                row.Cells["EmailTutor"].Value = tutor.Email;

                schedule.Insert(sub, tutor, LblStudentID.Text, STime, ETime, G2CmbxDateAvailable.SelectedValue, totalAmount, InvoiceID, totalHours);
                SlotsDateAvailable();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 16)
                    Result = ex.Message;
                else
                    MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateTotallbl();

        }

        private bool IsDraftSessiondateAndTimeExists()
        {
            bool IsExists = false;
            string conflictMessage = "We're unable to schedule this session as it conflicts with a pending session. \n\n";
            if (DGVStudent.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DGVStudent.Rows)
                {
                    if (row.Cells["StatusBill"].Value.ToString().Equals("Paid", StringComparison.OrdinalIgnoreCase)) continue;

                    TimeSpan sessionStart = DateTime.Parse(row.Cells["StartTime"].Value.ToString()).TimeOfDay;
                    TimeSpan sessionEnd = DateTime.Parse(row.Cells["EndTime"].Value.ToString()).TimeOfDay;
                    TimeSpan selectedStartTime = DateTime.Parse(G2CmbxStartTime.SelectedValue.ToString()).TimeOfDay;
                    TimeSpan selectedEndTime = DateTime.Parse(G2CmbxEndTime.SelectedValue.ToString()).TimeOfDay;

                    if (row.Cells["StatusBill"].Value.ToString().Equals("Pending", StringComparison.OrdinalIgnoreCase) &&
                        row.Cells["SessionDate"].Value.ToString().Equals(G2CmbxDateAvailable.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if ((selectedStartTime >= sessionStart && selectedStartTime < sessionEnd) ||
                            (selectedEndTime > sessionStart && selectedEndTime <= sessionEnd) ||
                            (selectedStartTime <= sessionStart && selectedEndTime >= sessionEnd) || selectedStartTime == sessionEnd || selectedEndTime == sessionStart)
                        {
                            string overlappingTime = $"{sessionStart} - {sessionEnd}";
                            string subject = row.Cells["Subject"].Value.ToString();
                            string tutorName = row.Cells["TutorName"].Value.ToString();
                            string Sessiondate = row.Cells["SessionDate"].Value.ToString();

                            conflictMessage += $"Conflicting Pending Session:\nSubject: {subject}\nTutor: {tutorName}\nDate: {Sessiondate}\nTime: {overlappingTime}\n\n" +
                                $"If you would like to proceed with this new session, please cancel the existing pending session first.";

                            MessageBox.Show(conflictMessage, "Scheduling Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            IsExists = true;
                            break;
                        }
                    }
                }
            }
            return IsExists;
        }
        private void UpdateTotallbl()
        {
            string total = string.Empty;
            schedule.UpdateTotal(DGVStudent, ref total);
            LblGrandTotal.Text = total;
        }

        private void validationSched()
        {
            MSession session = new MSession();
            session.StartTime = (TimeSpan)G2CmbxStartTime.SelectedValue;
            session.EndTime = (TimeSpan)G2CmbxEndTime.SelectedValue;
            session.SessionDate = Convert.ToDateTime(G2CmbxDateAvailable.SelectedValue);
            session.TutorID = Convert.ToInt32(LblTutorID.Text);
            session.StudentID = Convert.ToInt32(LblStudentID.Text);
            schedule.Validation(session);
        }

        private bool ValidateStartAndEndTime()
        {
            TimeSpan STime = (TimeSpan)G2CmbxStartTime.SelectedValue;
            TimeSpan ETime = (TimeSpan)G2CmbxEndTime.SelectedValue;

            if (STime == ETime)
            {
                MessageBox.Show("Start time and End time must not be equal", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (ETime < STime)
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
            schedule.SubtractCancel(DGVStudent, GrandTotal, ref UpdateGrandTotal);

            LblGrandTotal.Text = UpdateGrandTotal;

            SlotsDateAvailable();
        }

        private void guna2TextBoxCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private bool IsSufficientCash()
        {
            if (string.IsNullOrEmpty(guna2TextBoxCash.Text))
            {
                MessageBox.Show("Please enter a valid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal cash = Convert.ToDecimal(guna2TextBoxCash.Text);
            decimal TotalAmount = Convert.ToDecimal(LblGrandTotal.Text.Replace("P", "").Trim());

            if (cash < TotalAmount)
            {
                MessageBox.Show("Insufficient cash amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void guna2TextBoxCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                if (!IsSufficientCash()) return;

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
            if (!IsSufficientCash()) return;

            MStudent stud = new MStudent();
            stud.StudentID = Convert.ToInt32(LblStudentID.Text);
            stud.StudentName = G2TxbxFullname.Text;
            stud.Cash = Convert.ToDecimal(guna2TextBoxCash.Text);
            stud.Changed = Convert.ToDecimal(guna2TextBoxChange.Text);
            stud.ContactDetails = LblEmail.Text;

            schedule.PaidStatusBill(DGVStudent);
            bool HasError = schedule.FillInInvoices(DGVStudent, stud);
            if (HasError) return;

            MarkAsPaid();
            emptyfield();
        }

        private void emptyfield()
        {
            LblGrandTotal.Text = string.Empty;
            guna2TextBoxCash.Text = string.Empty;
            guna2TextBoxChange.Text = string.Empty;
        }

        private void MarkAsPaid()
        {
            foreach (DataGridViewRow row in DGVStudent.Rows)
            {
                if (row.Cells["StatusBill"].Value.ToString().Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    row.Cells["StatusBill"].Value = "Paid";
            }
        }

        private void DGVStudent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = DGVStudent.Rows[e.RowIndex];
            string status = row.Cells["StatusBill"].Value.ToString();

            if (status == "Paid")
                row.DefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153);
            else if (status == "Pending")
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
        }
    }
}
