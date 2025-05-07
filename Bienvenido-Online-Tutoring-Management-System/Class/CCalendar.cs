using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CCalendar
    {
        public List<MSession> GetSessionsForDayTutor(int Day)
        {
            return DataLoader.ExecuteStoredProcedure("Calendar_", new Dictionary<string, object> { { "Action", "Tutor" } }, reader => new MSession
            {
                //StudentID = int.Parse(reader["StudentID"].ToString()),
                //TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["TutorName"].ToString(),
                StudName = reader["StudName"].ToString(),
                Subject = reader["Subject"].ToString(),
                StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                //SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                //HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString()),
                //TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                //Status = reader["Status"].ToString(),
                //StatusBill = reader["StatusBill"].ToString(),
                //InvoiceID = int.Parse(reader["InvoiceID"].ToString()),
                //TotalHours = Convert.ToDecimal(reader["TotalHours"].ToString()),
                //SessionID = int.Parse(reader["SessionID"].ToString())
            });
        }
        public List<MSession> GetSessionsForDayStudent(int Day)
        {
            return DataLoader.ExecuteStoredProcedure("Calendar_", new Dictionary<string, object> { { "Action", "SessionDateShowAll" } }, reader => new MSession
            {
                //StudentID = int.Parse(reader["StudentID"].ToString()),
                //TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["TutorName"].ToString(),
                StudName = reader["StudName"].ToString(),
                Subject = reader["Subject"].ToString(),
                StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                Status = reader["Status"].ToString(),
                //HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString()),
                //TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                //StatusBill = reader["StatusBill"].ToString(),
                //InvoiceID = int.Parse(reader["InvoiceID"].ToString()),
                //TotalHours = Convert.ToDecimal(reader["TotalHours"].ToString()),
                //SessionID = int.Parse(reader["SessionID"].ToString())
            });
        }
    }
}
