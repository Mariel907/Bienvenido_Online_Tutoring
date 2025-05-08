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
    public partial class ListSessionsCalendar : UserControl
    {
        public ListBox lstBx { get {return lstSessions; } }
        private CustomCalendar _calendar;
        //private EFCalendarSched eFCalendarSched = new EFCalendarSched();
        public ListSessionsCalendar(CustomCalendar calendar)
        {
            InitializeComponent();
            _calendar = calendar;
        }

        private void lstSessions_MouseMove(object sender, MouseEventArgs e)
        {
            //int index = lstSessions.IndexFromPoint(e.Location);
            //if (index >= 0 && lstSessions.Items.Count > index)
            //{
            //    string sessionDetails = lstSessions.Items[index].ToString();
            //    string status = _calendar.GetStatusFromSession(sessionDetails);

            //    if (eFCalendarSched == null || eFCalendarSched.IsDisposed)
            //    {
            //        eFCalendarSched = new EFCalendarSched(sessionDetails, status);
            //        eFCalendarSched.Location = Cursor.Position;

            //        eFCalendarSched.Show();
            //    }
            //}
        }
    }
}
