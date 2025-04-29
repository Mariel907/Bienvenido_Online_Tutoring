using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CAutoIncrementID
    {
        public static int SubjectID;
        private static int TutorID;
        private static int AvailalbilityID;
        private static int StudentID;
        private static int SessionID;
        private static int GetNextID(string storedProcedure, int defaultValue, ref int counter, string Action)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(storedProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Action", Action);
                    object result = cmd.ExecuteScalar();

                    counter = result != null ? Convert.ToInt32(result) : defaultValue;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return counter++;
        }

        public static int SSubjectID() => GetNextID("NextID", 10000, ref SubjectID, "SubjectsID");
        public static int NextSubjectID()
        {
            SSubjectID();
            return SubjectID;
        }

        public static int TTutor() => GetNextID("NextID", 1000, ref TutorID, "TutorsID");
        public static int NextTutorID()
        {
            TTutor();
            return TutorID;
        }
        public static int AAvailability() => GetNextID("NextID", 100, ref AvailalbilityID, "TutorAvailability");
        public static int NextAvailability()
        {
            AAvailability();
            return AvailalbilityID;
        }

        public static void SStudent() => GetNextID("NextID", 100000, ref StudentID, "Students");
        public static int NextStudentID()
        {
            SStudent();
            return StudentID;
        }

        public static void Session() => GetNextID("NextID", 1000000, ref SessionID, "Sessions");
        public static int NextSessionID()
        {
            Session();
            return SessionID;
        }
    }
}
