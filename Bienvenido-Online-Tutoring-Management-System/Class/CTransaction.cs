using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CTransaction
    {
        private DataLoader _loader = new DataLoader();
        public void Search(string Cmbx, DataGridView DGV)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("StudentName", Cmbx),
                new SqlParameter("Action", "StudentName")
            };
            _loader.LoadData("Transaction_Search", DGV, sp);
        }

        public static List<MStudent> StudentsName()
        {
            return DataLoader.ExecuteStoredProcedure("Transaction_Search", new Dictionary<string, object> { { "Action", "ShowCmbxStudentName" } }, reader => new MStudent
            {
                StudentName = reader["StudentName"].ToString(),
            });
        }
    }
}
