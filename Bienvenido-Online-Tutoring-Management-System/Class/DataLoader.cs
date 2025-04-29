using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bienvenido_Online_Tutoring_Management_System.Model;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class DataLoader
    {
        public void LoadData(string query, DataGridView datagridView, SqlParameter[] parameters = null, bool isStoredProcedure = true)
        {
            using (SqlConnection conn = new SqlConnection(GlobalConnection.Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (isStoredProcedure)
                        cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    Adapter.Fill(dataTable);
                    if (datagridView != null)
                    {
                        datagridView.DataSource = dataTable;
                    }
                }
            }
        }

        public void ExecuteData(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GlobalConnection.Connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SearchTxbx(string query, string searchtext, DataGridView dataGridView)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Searchtext", searchtext)
            };
            LoadData(query, dataGridView, parameters);
        }
        public int LblUpdate(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(GlobalConnection.Connection))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static List<T> ExecuteStoredProcedure<T>(string storeProcedureName, Dictionary<string, object> parameters, Func<SqlDataReader, T> mapFunction)
        {
            List<T> result = new List<T>();
            using (SqlConnection con = new SqlConnection(GlobalConnection.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(storeProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(mapFunction(reader));
                        }
                    }
                }
            }
            return result;
        }
    }
}
