using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
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

        private void G2NmrcUPDown_ValueChanged(object sender, EventArgs e)
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
                    G2CmbxAvailableTime.DataSource = timeslots;
                    G2CmbxAvailableTime.DisplayMember = "ToString";
                }
                else
                    G2CmbxAvailableTime.DataSource = null;
            }
            else
                MessageBox.Show("Invalid date selected.", "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            MSubjects sub = G2CmbxPreferredSubjects.SelectedItem as MSubjects;
            MTutorProfile tutor = G2CmbxTutorName.SelectedItem as MTutorProfile;
            try
            {
                int sessionID = CAutoIncrementID.NextSessionID();

                decimal totalHours = (decimal)(DTPEndTime.Value - DTPStartTime.Value).TotalHours;
                decimal totalAmount = totalHours * tutor.HourlyRate;

                int rowIndex = DGVStudent.Rows.Add();
                DataGridViewRow row = DGVStudent.Rows[rowIndex];
                row.Cells["SessionID"].Value = sessionID;
                row.Cells["TutorID"].Value = tutor.TutorID;
                row.Cells["TutorName"].Value = tutor.Fullname;
                row.Cells["Subject"].Value = sub.SubjectName;
                row.Cells["StartTime"].Value = DTPStartTime.Value.TimeOfDay;
                row.Cells["EndTime"].Value = DTPEndTime.Value.TimeOfDay;
                row.Cells["HourlyRate"].Value = tutor.HourlyRate;
                row.Cells["TotalAmount"].Value = totalAmount;
                row.Cells["SessionDate"].Value = G2CmbxDateAvailable.SelectedValue;

                schedule.Insert(sub, tutor, LblStudentID.Text, DTPStartTime.Value, DTPEndTime.Value,G2CmbxDateAvailable.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string total = string.Empty;
            schedule.UpdateTotal(DGVStudent, ref total);
            labelTotal.Text = total;

            SlotsDateAvailable();
        }

        private void G2CmbxPreferredSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            TutorExprtise();
        }

        private void G2TxbxFullname_TextChanged(object sender, EventArgs e)
        {
        }

        private void LblStudentID_TextChanged(object sender, EventArgs e)
        {
        }

        private void G2BtnVoid_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = DGVStudent.SelectedRows[0];
            MSession session = new MSession();
            session.SessionID = Convert.ToInt32(selectedRow.Cells["SessionID"].Value.ToString());

            schedule.Void(session);
        }

        private void DTPStartTime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
