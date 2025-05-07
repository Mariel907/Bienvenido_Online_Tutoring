using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class FCalendar : Form
    {
        private int month = DateTime.Now.Month;
        private int year = DateTime.Now.Year;
        private CCalendar cCalendar = new CCalendar();


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
            if (month > 12)
            {
                month++;
                year++;
            }
            else
            {
                month++;
            }
            DaysCalendar();
        }

        private void PctrPrevious_Click(object sender, EventArgs e)
        {
            if (month > 12)
            {
                month--;
                year--;
            }
            else
            {
                month--;
            }
            DaysCalendar();
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
                List<MSession> sessionData = cCalendar.GetSessionsForDayStudent(day);
                //List<MSession> sessionList = cCalendar.GetSessionsForDayTutor(day);

                //sessionData.AddRange(sessionList);
                DateTime targetDate = new DateTime(year, month, day);

                dayControl.UpdateSessions(sessionData, targetDate);
                TblLytPnlCalendar.Controls.Add(dayControl, column, row);
            }
        }
        private void RefreshCalendar(string statusFilter)
        {
            TblLytPnlCalendar.Controls.Clear();
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DayOfWeek startDay = firstDayOfMonth.DayOfWeek;

            int firstDayColumn = (int)startDay;
            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                CustomCalendar dayControl = new CustomCalendar(day);
                int row = (day + firstDayColumn - 1) / 7;
                int column = (day + firstDayColumn - 1) % 7;
                List<MSession> sessionData = cCalendar.GetSessionsForDayStudent(day);

                if(!string.IsNullOrEmpty(statusFilter))
                    sessionData = sessionData.Where(s => s.Status == statusFilter).ToList();

                DateTime targetDaet = new DateTime(year, month, day);
                dayControl.UpdateSessions(sessionData, targetDaet);

                TblLytPnlCalendar.Controls.Add(dayControl);
            }
        }

        private void CHKDone_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKDone.Checked)
                RefreshCalendar("Done");
            else
                RefreshCalendar("");
        }

        private void CHKScheduled_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKScheduled.Checked)
                RefreshCalendar("Scheduled");
            else
                RefreshCalendar("");
        }

        private void CHKOnGoing_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKOnGoing.Checked)
                RefreshCalendar("OnGoing");
            else
                RefreshCalendar("");
        }
    }
}
