using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                Fullname = reader["Fullname"].ToString(),
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
        public static Dictionary<DateTime, List<TimeSpan>> GetTimeslotsByDate(string TutorID, string Day)
        {
            Slots slots = new Slots { GroupedTimeslots = new Dictionary<DateTime, List<TimeSpan>>() };

            DataLoader.ExecuteStoredProcedure(
                "Days_",
                new Dictionary<string, object>
                {
            { "Action", Day },
            { "TutorID", TutorID },
                    {"SlotInterval", }
                },
                reader =>
                {
                    string timeSlotsAvailable = reader["TimeSlotsAvailable"]?.ToString() ?? string.Empty;
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
                if (row.Cells["TotalAmount"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                }
            }
            Label = "P" + totalAmount.ToString("N2");
        }

        public void Insert(MSubjects sub, MTutorProfile tutor, string StudID, object SDate, object EDate, object date)
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
            };
            _loader.ExecuteData("Schedule_ShowAdd", sp);
        }

        public void Void(MSession session)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("SessionID", session.SessionID),
                new SqlParameter("Action", "Void")
            };
            _loader.ExecuteData("Schedule_ShowAdd", sp);
        }
        
        public void Validation()
        {

        }
    }
}
