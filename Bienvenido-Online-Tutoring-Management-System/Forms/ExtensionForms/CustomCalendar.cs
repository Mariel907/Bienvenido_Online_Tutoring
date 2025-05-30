using Bienvenido_Online_Tutoring_Management_System.Model;
using Bienvenido_Online_Tutoring_Management_System.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class CustomCalendar : UserControl
    {
        private EFCalendarSched eFCalendarSched;
        public int Day { get; set; }
        public List<MSession> Sessions { get; set; } = new List<MSession>();
        public Color CalendarColor { get; set; }

        public CustomCalendar(int day, int year, int month, Color bgColor)
        {
            InitializeComponent();
            Day = day;
            LblDay.Text = day.ToString();
            WhatDayToday(day, month, year);
            CalendarColor = bgColor;
            LblDay.ForeColor = bgColor;
            _ = LoadWeatherAsync(day, year, month);
        }
        private void WhatDayToday(int day, int month, int year)
        {
            if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                LblDay.BackColor = Color.FromArgb(188, 184, 177);
            else
                LblDay.BackColor = Color.FromArgb(250, 249, 246);
        }

        public async Task LoadWeatherAsync(int day, int year, int month)
        {
            var weatherDataByDay = await GetWeatherForMonth(year, month);
               Lblweather.Text = weatherDataByDay[day].temp;
            if (File.Exists(weatherDataByDay[day].image))
                Pctr.Image = Image.FromFile(weatherDataByDay[day].image);
            else
                MessageBox.Show("Image file not found: " + weatherDataByDay[day].image);
        }

        public static async Task<Dictionary<int, (string temp, string image)>> GetWeatherForMonth(int year, int month)
        {
            string apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=7.051399&longitude=125.59477&hourly=temperature_2m,rain,precipitation,relative_humidity_2m,dew_point_2m&timezone=auto";

            Dictionary<int,( string temp, string image)> weatherDataByDay = new Dictionary<int, (string, string)>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject weatherData = JObject.Parse(jsonResponse);

                    var temp = weatherData["hourly"]["temperature_2m"];
                    var rain = weatherData["hourly"]["rain"];
                    var humidity = weatherData["hourly"]["relative_humidity_2m"];

                    int totalDays = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= totalDays; day++)
                    {
                        int totalHoursAvailable = temp.Count();
                        int hoursPerDay = totalHoursAvailable / totalDays; 
                        int hourIndex = (day - 1) * hoursPerDay + hoursPerDay / 2; 

                        string temperature = temp?[hourIndex]?.ToString() ?? "N/A";
                        //string rainVolume = rain?[hourIndex]?.ToString() ?? "N/A";
                        //string humidityValue = humidity?[hourIndex]?.ToString() ?? "N/A";

                        string imagePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources\\Cold.png");
                        if(double.TryParse(temperature, out double tempValue))
                        {
                            if(tempValue > 30) imagePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources\\Sun.png");
                            else if (tempValue > 20) imagePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources\\warm.png");
                            else if(tempValue > 10) imagePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources\\Cold.png");

                        }
                        weatherDataByDay[day] = (temperature + "°C", imagePath);
                    }
                }
                else
                {
                    string image = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources\\error.png");
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        weatherDataByDay[day] = ("No Data", image);
                    }
                }
            }

            return weatherDataByDay;
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
