using Bienvenido_Online_Tutoring_Management_System.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CStudents
    {
        private DataLoader dl = new DataLoader();
        public static List<MStudent> Students()
        {
            return DataLoader.ExecuteStoredProcedure("Student_AddEditShow", new Dictionary<string, object> { { "Action", "Show" } }, reader => new MStudent
            {
                StudentID = int.Parse(reader["StudentID"].ToString()),
                Firstname = reader["Firstname"].ToString(),
                Lastname = reader["Lastname"].ToString(),
                ContactDetails = reader["ContactDetails"].ToString(),
                PrefferedSubjects = reader["PreferredSubjects"].ToString(),
                StudentName = reader["Fullname"].ToString()
            });
        }
        public void Insert(MStudent stud)
        {
            int studID = CAutoIncrementID.NextStudentID();
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action","Add"),
                new SqlParameter("Firstname", stud.Firstname),
                new SqlParameter("Lastname", stud.Lastname),
                new SqlParameter("PreferredSubjects", stud.PrefferedSubjects),
                new SqlParameter("ContactDetails", stud.ContactDetails),
                new SqlParameter("StudentID", studID)
            };
            dl.ExecuteData("Student_AddEditShow", sp);
        }

        public void Update(MStudent stud)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "Update"),
                new SqlParameter("StudentID", stud.StudentID),
                new SqlParameter("Firstname", stud.Firstname),
                new SqlParameter("Lastname", stud.Lastname),
                new SqlParameter("PreferredSubjects", stud.PrefferedSubjects),
                new SqlParameter("ContactDetails", stud.ContactDetails)
            };
            dl.ExecuteData("Student_AddEditShow", sp);
        }
        public void Search(string Txbx, DataGridView DGV)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action","SearchTxbx"),
                new SqlParameter("Txbx", Txbx)
            };
            dl.LoadData("Search_Student", DGV, sp);
        }
    }
}
