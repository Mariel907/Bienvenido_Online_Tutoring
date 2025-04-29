using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CFSubjects
    {
        private DataLoader dataLoader = new DataLoader();
        public static List<MSubjects> Subjects()
        {
            return DataLoader.ExecuteStoredProcedure("Subject_UpdateDeleteAdd", new Dictionary<string, object> { { "Action", "Show"} }, reader => new MSubjects
            {
                SubjectName = reader["SubjectName"].ToString(),
                SubID = int.Parse(reader["SubjectID"].ToString())
            });
        }

        public void ExecuteAction(string action, MSubjects sub)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int ID = CAutoIncrementID.NextSubjectID();

            switch (action)
            {
                case "Add":
                    parameters.Add(new SqlParameter("Action", "Add"));
                    parameters.Add(new SqlParameter("ID", ID));
                    parameters.Add(new SqlParameter("SubName", sub.SubjectName));
                    break;

                case "Update":
                    parameters.Add(new SqlParameter("Action", "Update"));
                    parameters.Add(new SqlParameter("ID", sub.SubID));
                    parameters.Add(new SqlParameter("SubName", sub.SubjectName));
                    break;

                case "Delete":
                    parameters.Add(new SqlParameter("Action", "Delete"));
                    parameters.Add(new SqlParameter("ID", sub.SubID));
                    break;

                default:
                    throw new ArgumentException("Invalid action provided");
            }

            dataLoader.ExecuteData("Subject_UpdateDeleteAdd", parameters.ToArray());
        }

    }
}
