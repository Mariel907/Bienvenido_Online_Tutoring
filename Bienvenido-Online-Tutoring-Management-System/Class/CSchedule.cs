using Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class CSchedule
    {
        private DataLoader _loader = new DataLoader();
        public static List<MSubjects> PreferredSubjects(string StudID)
        {
            return DataLoader.ExecuteStoredProcedure("Schedule_ShowAdd", new Dictionary<string, object> { { "Action", "PreferredSubjects" }, { "StudentID", StudID } }, reader => new MSubjects
            {
                StudentID = int.Parse(reader["StudentID"].ToString()),
                SubjectName = reader["Subjects"].ToString(),
            });
        }

        public static List<MTutorProfile> TutorExpertise(string Expertise)
        {
            return DataLoader.ExecuteStoredProcedure("Schedule_ShowAdd", new Dictionary<string, object> { { "Action", "Tutor" }, { "Expertise", Expertise } }, reader => new MTutorProfile
            {
                TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["Fullname"].ToString(),
                HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString())
            });
        }

        public static List<MTutorProfile> AvailableDay(string TutorID)
        {
            return DataLoader.ExecuteStoredProcedure("Schedule_ShowAdd", new Dictionary<string, object> { { "Action", "AvailableDay" }, { "TutorID", TutorID } }, reader => new MTutorProfile
            {
                TutorID = int.Parse(reader["TutorID"].ToString()),
                DaysAvailable = reader["AvailableDay"].ToString(),
            });
        }
        public static List<MSession> ShowScheduled(string StudentID)
        {
            return DataLoader.ExecuteStoredProcedure("Schedule_ShowAdd", new Dictionary<string, object> { { "Action", "ShowSchedStudent" }, { "StudentID", StudentID } }, reader => new MSession
            {
                StudentID = int.Parse(reader["StudentID"].ToString()),
                TutorID = int.Parse(reader["TutorID"].ToString()),
                TutorName = reader["TutorName"].ToString(),
                Subject = reader["Subject"].ToString(),
                StartTime = Convert.ToDateTime(reader["StartTime"].ToString()).TimeOfDay,
                EndTime = Convert.ToDateTime(reader["EndTime"].ToString()).TimeOfDay,
                SessionDate = Convert.ToDateTime(reader["SessionDate"].ToString()).Date,
                HourlyRate = Convert.ToDecimal(reader["HourlyRate"].ToString()),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                Status = reader["Status"].ToString(),
                StatusBill = reader["StatusBill"].ToString(),
                InvoiceID = int.Parse(reader["InvoiceID"].ToString()),
                TotalHours = Convert.ToDecimal(reader["TotalHours"].ToString()),
                SessionID = int.Parse(reader["SessionID"].ToString())
            });
        }

        public static Dictionary<DateTime, List<TimeSpan>> GetTimeslotsByDate(string TutorID, string Day)
        {
            Slots slots = new Slots { GroupedTimeslots = new Dictionary<DateTime, List<TimeSpan>>() };

            DataLoader.ExecuteStoredProcedure(
                "Days_",
                new Dictionary<string, object>
                {
            { "Action", Day },
            { "TutorID", TutorID }
                },
                reader =>
                {
                    string timeSlotsAvailable = reader["TimeSlot"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(timeSlotsAvailable))
                    {
                        if (DateTime.TryParse(reader["NextTargetDate"]?.ToString(), out DateTime dateSlot))
                        {
                            if (!slots.GroupedTimeslots.ContainsKey(dateSlot))
                            {
                                slots.GroupedTimeslots[dateSlot] = new List<TimeSpan>();
                            }

                            string[] splitTimeSlots = timeSlotsAvailable.Split(',');

                            foreach (string slot in splitTimeSlots)
                            {
                                if (TimeSpan.TryParse(slot.Trim(), out TimeSpan parsedSlot))
                                {
                                    slots.GroupedTimeslots[dateSlot].Add(parsedSlot);
                                }
                            }
                        }
                    }
                    return slots.GroupedTimeslots;
                });

            return slots.GroupedTimeslots;
        }
        public void UpdateTotal(DataGridView datagridView, ref string Label)
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in datagridView.Rows)
            {
                if (row.Cells["TotalAmount"].Value != null && row.Cells["StatusBill"].Value.ToString().Equals("Pending", StringComparison.OrdinalIgnoreCase))
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                }
            }
            Label = "P" + totalAmount.ToString("N2");
        }

        public void Insert(MSubjects sub, MTutorProfile tutor, string StudID, object SDate, object EDate, object date, decimal totalAmount, int InvoiceID, decimal totalHours)
        {
            int SessionID = CAutoIncrementID.NextSessionID();
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("SessionID", SessionID),
                new SqlParameter("TutorID", tutor.TutorID),
                new SqlParameter("StudentID", StudID),
                new SqlParameter("SessionDate", date),
                new SqlParameter("StartTime",SDate),
                new SqlParameter("EndTime", EDate),
                new SqlParameter("Action", "AddSchedule"),
                new SqlParameter("TotalAmount", totalAmount),
                new SqlParameter("Subject", sub.SubjectName),
                new SqlParameter("InvoiceID", InvoiceID),
                new SqlParameter("TotalHours", totalHours)
            };
            _loader.ExecuteData("Schedule_ShowAdd", sp);
        }

        public void Void(DataGridView DGV)
        {
            DataGridViewRow row = DGV.SelectedRows[0];
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("SessionID", row.Cells["SessionID"].Value),
                new SqlParameter("InvoiceID", row.Cells["InvoiceID"].Value),
                new SqlParameter("Action", "Void")
            };
            _loader.ExecuteData("Schedule_ShowAdd", sp);
        }

        public void SubtractCancel(DataGridView DGV, string label, ref string _UpdateLabel)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                decimal TotalAmountToSubtract = 0;
                foreach (DataGridViewRow row in DGV.SelectedRows)
                {
                    TotalAmountToSubtract += Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                    DGV.Rows.RemoveAt(row.Index);
                }
                decimal GrandTotal = Convert.ToDecimal(label.Replace("P", "").ToString());

                GrandTotal -= TotalAmountToSubtract;
                _UpdateLabel = "P" + GrandTotal.ToString("N2");
            }
        }

        public void CalculateChange(decimal totalAmount, decimal Cash, ref string Change)
        {
            decimal cashGiven = Cash;
            decimal change = cashGiven - totalAmount;
            Change = change.ToString("N2");
        }

        public void Validation(MSession session)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Action", "Validation"),
                new SqlParameter("StartTime", session.StartTime),
                new SqlParameter("EndTime", session.EndTime),
                new SqlParameter("SessionDate", session.SessionDate),
                new SqlParameter("TutorID", session.TutorID),
                new SqlParameter("StudentID", session.StudentID)
            };
            _loader.ExecuteData("Schedule_ShowAdd", sp);
        }

        public void ValidationDraft(DataGridView DGV)
        {
            string Result = string.Empty;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["StatusBill"].Value.ToString().Equals("Paid", StringComparison.OrdinalIgnoreCase)) continue;
                try
                {

                    SqlParameter[] sp = new SqlParameter[]
                    {
                    new SqlParameter("Action", "ValidationDraft"),
                    new SqlParameter("SessionDate", row.Cells["SessionDate"].Value),
                    new SqlParameter("StartTime", row.Cells["StartTime"].Value),
                    new SqlParameter("EndTime", row.Cells["EndTime"].Value)
                    };
                    _loader.ExecuteData("Schedule_ShowAdd", sp);
                }
                catch (SqlException ex)
                {

                    if (ex.Class == 16 && ex.Message.Contains("Conflict_Trigger"))
                    {
                        string Message = $"System canceled the session because the other student already paid this session:\n" +
                            $"TutorName: {row.Cells["TutorName"].Value}\n" +
                            $"Subject: {row.Cells["Subject"].Value}\n" +
                            $"Start Time: {row.Cells["StartTime"].Value}\n" +
                            $"End Time: {row.Cells["EndTime"].Value}\n" +
                            $"Date Scheduled: {row.Cells["SessionDate"].Value}";
                        MessageBox.Show(Message, "Scheduled Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void FillInInvoices(DataGridView DGV, MStudent stud)
        {
            var list = new List<MSession>();
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["StatusBill"].Value != null &&
            row.Cells["StatusBill"].Value.ToString().Equals("Paid", StringComparison.OrdinalIgnoreCase))
                    continue;

                var session = new MSession();

                session.TutorName = row.Cells["TutorName"].Value.ToString();
                session.Subject = row.Cells["Subject"].Value.ToString();
                session.SessionDate = Convert.ToDateTime(row.Cells["SessionDate"].Value.ToString());
                session.StartTime = Convert.ToDateTime(row.Cells["StartTime"].Value.ToString()).TimeOfDay;
                session.EndTime = Convert.ToDateTime(row.Cells["EndTime"].Value.ToString()).TimeOfDay;
                session.HourlyRate = Convert.ToDecimal(row.Cells["HourlyRate"].Value.ToString());
                session.TotalAmount = Convert.ToDecimal(row.Cells["TotalAmount"].Value.ToString());
                session.TotalHours = Convert.ToDecimal(row.Cells["TotalHours"].Value.ToString());

                list.Add(session);
            }
            RecieptSched rs = new RecieptSched(list, stud);
            rs.ShowDialog();
        }

        public void PaidStatusBill(DataGridView DGV)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["StatusBill"].Value.ToString().Equals("Paid", StringComparison.OrdinalIgnoreCase)) continue;

                SqlParameter[] sp = new SqlParameter[]
                {
                  new SqlParameter("Action", "Paid"),
                  new SqlParameter("InvoiceID", row.Cells["InvoiceID"].Value),
                  new SqlParameter("SessionID", row.Cells["SessionID"].Value)
                };

                _loader.ExecuteData("Schedule_ShowAdd", sp);
            }
        }

        
    }
}
