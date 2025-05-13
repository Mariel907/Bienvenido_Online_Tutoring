using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class FCalendar : Form
    {
        private int month = DateTime.Now.Month;
        private int year = DateTime.Now.Year;
        private CCalendar cCalendar = new CCalendar();
        private string cmbx;
        public FCalendar()
        {
            InitializeComponent();
        }

        private void FCalendar_Load(object sender, EventArgs e)
        {
            DaysCalendar();
        }

        private void PCtrNext_Click(object sender, EventArgs e)
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            StatusChecked();
        }

        private void PctrPrevious_Click(object sender, EventArgs e)
        {
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }
            StatusChecked();
        }

        private void DaysCalendar()
        {

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LblMonth.Text = $"{monthName}  {year}";

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DayOfWeek startDay = firstDayOfMonth.DayOfWeek;

            int firstDayColumn = (int)startDay;
            TblLytPnlCalendar.Controls.Clear();
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                CustomCalendar dayControl = new CustomCalendar(day);
                int row = (day + firstDayColumn - 1) / 7;
                int column = (day + firstDayColumn - 1) % 7;
                List<MSession> sessionData = cCalendar.GetSessionsForDayBoth(day);
                //List<MSession> sessionList = cCalendar.GetSessionsForDayTutor(day);

                //sessionData.AddRange(sessionList);
                DateTime targetDate = new DateTime(year, month, day);

                dayControl.UpdateSessions(sessionData, targetDate);
                TblLytPnlCalendar.Controls.Add(dayControl, column, row);
            }
        }
        private void RefreshCalendar(List<string> statusFilter)
        {
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LblMonth.Text = $"{monthName}  {year}";

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DayOfWeek startDay = firstDayOfMonth.DayOfWeek;

            int firstDayColumn = (int)startDay;

            string searchedName = G2CmbxName.Text;

            TblLytPnlCalendar.Controls.Clear();
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                CustomCalendar dayControl = new CustomCalendar(day);
                int row = (day + firstDayColumn - 1) / 7;
                int column = (day + firstDayColumn - 1) % 7;
                List<MSession> sessionData = cCalendar.GetSessionsForDayBoth(day);

                if (sessionData.Any())
                {
                    sessionData = sessionData.Where(s =>
                        (string.IsNullOrEmpty(searchedName) || s.StudName.Contains(searchedName) || s.TutorName.Contains(searchedName))
                        && (!statusFilter.Any() || statusFilter.Contains(s.Status)) // Ensures filtering works even if no status is selected
                    ).ToList();
                }

                DateTime targetDaet = new DateTime(year, month, day);
                dayControl.UpdateSessions(sessionData, targetDaet);

                TblLytPnlCalendar.Controls.Add(dayControl, column, row);
            }
        }

        private void CHK_CheckedChanged(object sender, EventArgs e)
        {
            StatusChecked();
        }
        private void StatusChecked()
        {
            List<string> selectedStatus = new List<string>();
            if (CHKDone.Checked) selectedStatus.Add("Done");
            if (CHKScheduled.Checked) selectedStatus.Add("Scheduled");
            if (CHKOnGoing.Checked) selectedStatus.Add("OnGoing");
            RefreshCalendar(selectedStatus);
        }
        private void CmbxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category();
        }

        private void Category()
        {
            cmbx = CmbxCategoryName.Text;
            var sessionDays = CCalendar.GetSessionsForDayStudent();
            if (cmbx == "Student")
            {
                G2CmbxName.DataSource = sessionDays;
                G2CmbxName.DisplayMember = "StudName";
                G2CmbxName.ValueMember = "StudentID";
            }
            else
            {
                G2CmbxName.DataSource = sessionDays;
                G2CmbxName.DisplayMember = "TutorName";
                G2CmbxName.ValueMember = "TutorID";
            }
        }

        private void G2CmbxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbx = CmbxCategoryName.Text;
            if (G2CmbxName.SelectedValue != null)
            {
                MSession session = G2CmbxName.SelectedItem as MSession;
                if (cmbx == "Student")
                    LblID.Text = session.StudentID.ToString();
                else
                    LblID.Text = session.TutorID.ToString();
            }
            StatusChecked();
        }

        private void CmbxCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
