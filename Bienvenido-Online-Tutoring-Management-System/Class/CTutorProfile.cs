using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CTutorProfile
    {
        private DataLoader dataLoader = new DataLoader();
        public static List<MTutorProfile> Tutors()
        {
            return DataLoader.ExecuteStoredProcedure("Tutor_AddUpdateDelete", new Dictionary<string, object> { { "Action", "Show" } }, reader => new MTutorProfile
            {
                TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["Fullname"].ToString(),
                Expertise = reader["Expertise"].ToString(),
                HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString()),
                AvailabilityID = int.Parse(reader["AvailabilityID"].ToString()),
                StartTime = TimeSpan.Parse(reader["StartTime"].ToString()),
                EndTime = TimeSpan.Parse(reader["EndTime"].ToString()),
                DaysAvailable = reader["DaysAvailable"].ToString(),
                Firstname = reader["Firstname"].ToString(),
                lastname = reader["Lastname"].ToString(),
                Email = reader["Email"].ToString()
            });
        }
        private static List<MSubjects> SubjectShow()
        {
            return DataLoader.ExecuteStoredProcedure("Subject_UpdateDeleteAdd", new Dictionary<string, object> { { "Action", "Show" } }, reader => new MSubjects
            {
                SubID = int.Parse(reader["SubjectID"].ToString()),
                SubjectName = reader["SubjectName"].ToString()
            });
        }
        
        public void Insert(MTutorProfile mTutor, List<string> SubExpert, DateTime STime, DateTime ETime)
        {
            string sub = string.Join(", ", SubExpert);
            int TutorID = CAutoIncrementID.NextTutorID();
            int AvailID = CAutoIncrementID.NextAvailability();
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("TutorID", TutorID),
                new SqlParameter("AvailabilityID", AvailID),
                new SqlParameter("Firstname", mTutor.Firstname),
                new SqlParameter("Lastname", mTutor.lastname),
                new SqlParameter("Expertise", sub),
                new SqlParameter("HourlyRate", mTutor.HourlyRate),
                new SqlParameter("StartTime", STime),
                new SqlParameter("EndTime", ETime),
                new SqlParameter("DaysAvailable", mTutor.DaysAvailable),
                new SqlParameter("Action", "Add"),
                new SqlParameter("Email", mTutor.Email )
            };
            dataLoader.ExecuteData("Tutor_AddUpdateDelete", sp);
        }

        public void Update(MTutorProfile tutor, List<string> SubExpert)
        {
            string sub = string.Join(", ", SubExpert);
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "Update"),
                new SqlParameter("Firstname", tutor.Firstname),
                new SqlParameter("Lastname", tutor.lastname),
                new SqlParameter("Expertise", sub),
                new SqlParameter("HourlyRate", tutor.HourlyRate),
                new SqlParameter("StartTime", tutor.StartTime),
                new SqlParameter("EndTime", tutor.EndTime),
                new SqlParameter("DaysAvailable", tutor.DaysAvailable),
                new SqlParameter("TutorID", tutor.TutorID),
                new SqlParameter("AvailabilityID", tutor.AvailabilityID),
                new SqlParameter("Email", tutor.Email),
            };
            dataLoader.ExecuteData("Tutor_AddUpdateDelete", sp);
        }

        public void Search(string Txbx, DataGridView Dgv)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "SearchTxbx"),
                new SqlParameter("Txbx", Txbx),
            };
            dataLoader.LoadData("Search_Tutor", Dgv, sp);
        }
    }
}
