using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CCalendar
    {
        private DataLoader DL = new DataLoader();
        public List<MSession> GetSessionsForDayTutor()
        {
            return DataLoader.ExecuteStoredProcedure("Calendar_", new Dictionary<string, object> { { "Action", "Tutor" } }, reader => new MSession
            {
                TutorName = reader["TutorName"].ToString(),
                Subject = reader["Subject"].ToString(),
                //StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                //EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                //SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                //Status = reader["Status"].ToString(),
            });
        }
        public static List<MSession> GetSessionsForDayStudent()
        {
            return DataLoader.ExecuteStoredProcedure("Calendar_", new Dictionary<string, object> { { "Action", "SessionDateShowAll" } }, reader => new MSession
            {
                StudName = reader["StudName"].ToString(),
                Subject = reader["Subject"].ToString(),
                TutorName = reader["TutorName"].ToString(),
                TutorID = int.Parse(reader["TUtorID"].ToString()),
                StudentID = int.Parse(reader["StudentID"].ToString())
                //StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                //EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                //SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                //Status = reader["Status"].ToString(),
            });
        }
        public List<MSession> GetSessionsForDayBoth(int Day)
        {
            return DataLoader.ExecuteStoredProcedure("Calendar_", new Dictionary<string, object> { { "Action", "SessionDateShowAll" } }, reader => new MSession
            {
                TutorName = reader["TutorName"].ToString(),
                StudName = reader["StudName"].ToString(),
                Subject = reader["Subject"].ToString(),
                StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                Status = reader["Status"].ToString(),
                TutorID = int.Parse(reader["TUtorID"].ToString()),
                StudentID = int.Parse(reader["StudentID"].ToString())
            });
        }
        public void UpdateStatus()
        {
            DL.LoadData("Session_", null, null);
        }

    }
}
