using Bienvenido_Online_Tutoring_Management_System.Model;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CTrackingEarnings
    {
        public static List<MSession> ShowEarnings(string ID, DateTime SDate, DateTime EDate)
        {
            return DataLoader.ExecuteStoredProcedure("Earnings_", new Dictionary<string, object> { { "Action", "TrackingEarnings" }, { "TutorID", ID }, { "StartDate", SDate }, { "EndDate", EDate } }, reader => new MSession
            {
                StudName = reader["StudName"].ToString(),
                Subject = reader["Subject"].ToString(),
                StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString()),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                StatusBill = reader["StatusBill"].ToString(),
                Status = reader["Status"].ToString(),
                SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()),
                SessionID = int.Parse(reader["SessionID"].ToString()),
                TutorID = int.Parse(reader["TutorID"].ToString()),
                StudentID = int.Parse(reader["StudentID"].ToString()),
                ContactDetails = reader["ContactDetails"].ToString(),
                PaidDate = Convert.ToDateTime(reader["PaidDate"])
            });
        }
    }
}
