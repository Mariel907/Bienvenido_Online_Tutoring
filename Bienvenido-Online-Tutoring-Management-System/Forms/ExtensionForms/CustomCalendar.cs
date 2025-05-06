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
    public partial class CustomCalendar : UserControl
    {
        public int Day {  get; set; }
        public List<MSession> Sessions { get; set; } = new List<MSession>();
        public CustomCalendar(int day)
        {
            InitializeComponent();
            Day = day;
            LblDay.Text = day.ToString();
        }

        public void UpdateSessions(List<MSession> sessionDetails)
        {
            Sessions = sessionDetails;
            lstSessions.Items.Clear();
            foreach(var session in sessionDetails)
            {
                lstSessions.Items.Add(session);
            }
        }
    }
}
