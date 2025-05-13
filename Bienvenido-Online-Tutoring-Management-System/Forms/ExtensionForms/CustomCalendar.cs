using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class CustomCalendar : UserControl
    {
        private EFCalendarSched eFCalendarSched;
        public int Day { get; set; }
        public List<MSession> Sessions { get; set; } = new List<MSession>();
        public CustomCalendar(int day)
        {
            InitializeComponent();
            Day = day;
            LblDay.Text = day.ToString();
            lstSessions.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public void UpdateSessions(List<MSession> sessionDetails, DateTime targetDate)
        {
            Sessions = sessionDetails.Where(s => s.SessionDate.Date == targetDate.Date).ToList();

            lstSessions.Items.Clear();
            foreach (var session in Sessions)
            {
                lstSessions.Items.Add($"{session.StartTime} - {session.EndTime}                                                                       \nSession Date : {session.SessionDate.ToString("MM/dd/yyyy")}  \nSubject : {session.Subject} \nStudent Name : {session.StudName} \nTutor Name: {session.TutorName} \nStatus : {session.Status}");
            }
        }
       
        private void lstSessions_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstSessions.IndexFromPoint(e.Location);
            if (index >= 0 && lstSessions.Items.Count > index)
            {
                string sessionDetails = lstSessions.Items[index].ToString();
                string status = GetStatusFromSession(sessionDetails);

                if (eFCalendarSched == null || eFCalendarSched.IsDisposed)
                {
                    eFCalendarSched = new EFCalendarSched(sessionDetails, status);
                    eFCalendarSched.Location = Cursor.Position;

                    eFCalendarSched.Show();
                }
            }
        }
        private string GetStatusFromSession(string sessionDetails)
        {
            if (sessionDetails.Contains("Done")) return "Done";
            if (sessionDetails.Contains("Scheduled")) return "Scheduled";
            if (sessionDetails.Contains("OnGoing")) return "OnGoing";
            return "Unknown";
        }
        private void lstSessions_MouseLeave(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i] is EFCalendarSched)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        private void lstSessions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string sessionDetails = lstSessions.Items[e.Index].ToString();
            Color backColor = Color.White;

            if (sessionDetails.Contains("Done")) backColor = Color.FromArgb(255, 128, 128);
            else if (sessionDetails.Contains("Scheduled")) backColor = Color.FromArgb(255, 255, 0);
            else if (sessionDetails.Contains("OnGoing")) backColor = Color.FromArgb(204, 255, 204);

            Rectangle bounds = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 2, e.Bounds.Width - 10, e.Bounds.Height - 4);
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 12;

                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            SolidBrush customBrush = new SolidBrush(Color.FromArgb(28, 42, 68));
            using (StringFormat format = new StringFormat())
            {
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(sessionDetails, e.Font, customBrush, bounds, format);
            }

            e.DrawFocusRectangle();
        }
    }
}
