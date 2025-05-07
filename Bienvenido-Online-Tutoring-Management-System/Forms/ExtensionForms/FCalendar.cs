using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class FCalendar : Form
    {
        private int month = DateTime.Now.Month;
        private int year = DateTime.Now.Year;

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
            CCalendar cCalendar = new CCalendar();

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
    }
}
