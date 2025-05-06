using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class FCalendar : Form
    {
        private int month, year;
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

        }

        private void DaysCalendar()
        {
            CCalendar cCalendar = new CCalendar();
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LblMonth.Text = $"{monthName}  {year}";

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DayOfWeek startDay = firstDayOfMonth.DayOfWeek;

            int firstDayColumn = (int)startDay;

            for (int day = 1; day <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); day++)
            {
                CustomCalendar dayControl = new CustomCalendar(day);
                int row = (day + firstDayColumn - 1) / 7;
                int column = (day + firstDayColumn -1) % 7;
                List<MSession> sessionData = cCalendar.GetSessionsForDayStudent(day);
                //List<MSession> sessionList = cCalendar.GetSessionsForDayTutor(day);

                //sessionData.AddRange(sessionList);
                dayControl.UpdateSessions(sessionData);

                TblLytPnlCalendar.Controls.Add(dayControl, column, row);
            }
        }
    }
}
