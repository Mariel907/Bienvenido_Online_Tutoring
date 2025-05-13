using Bienvenido_Online_Tutoring_Management_System.Model;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CEarnings
    {
        private DataLoader dl = new DataLoader();
        public static List<MSession> TutorSched(string TutorID)
        {
            return DataLoader.ExecuteStoredProcedure("Earnings_", new Dictionary<string, object> { { "Action", "TutorName" }, { "TutorID", TutorID } }, reader => new MSession
            {
                StudName = reader["StudentName"].ToString(),
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
                StudentID = int.Parse(reader["StudentID"].ToString())
            });
        }
        public static List<MTutorProfile> TutorShow()
        {
            return DataLoader.ExecuteStoredProcedure("Earnings_", new Dictionary<string, object> { { "Action", "ShowTutorName" } }, reader => new MTutorProfile
            {
                TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["_TutorName"].ToString()
            });
        }

        public void ShowDgvSched(string ID, DataGridView Dgv)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "TutorName"),
                new SqlParameter("TutorID", ID)
            };
            dl.LoadData("Earnings_", Dgv, sp);
        }
        public void Earnings(ref string lblEarnings, string Action, string LblId)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", Action),
                new SqlParameter("TutorID", LblId)
            };
          int count = dl.LblUpdate("Earnings_", sp);

          lblEarnings = "P" + count.ToString("N2");
        }

        public void SearchCmbx(DataGridView Dgv, string LblID, string Cmbx)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "Done"),
                new SqlParameter("TutorID", LblID),
                new SqlParameter("Status", Cmbx)
            };
            dl.LoadData("Earnings_", Dgv, sp);
        }
        public void Scheduled(DataGridView DGV, string LblID)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "Scheduled"),
                new SqlParameter("TUtorID", LblID)
            };
            dl.LoadData("Earnings_", DGV, sp);
        }
    }
}
