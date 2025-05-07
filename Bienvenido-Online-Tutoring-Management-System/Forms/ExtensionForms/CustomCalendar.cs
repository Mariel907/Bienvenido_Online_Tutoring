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

        public void UpdateSessions(List<MSession> sessionDetails, DateTime targetDate)
        {
            Sessions = sessionDetails.Where(s => s.SessionDate.Date == targetDate.Date).ToList();

            lstSessions.Items.Clear();
            foreach (var session in Sessions)
            {
                lstSessions.Items.Add($"{session.StartTime} - {session.EndTime}");
            }
        }

        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstSessions.SelectedIndex >= 0)
            {
                string selectedSession = lstSessions.SelectedItem.ToString();

            }
        }

        private void lstSessions_MouseHover(object sender, EventArgs e)
        {
            if(lstSessions.SelectedIndex >= 0)
            {

            }
        }
    }
}
