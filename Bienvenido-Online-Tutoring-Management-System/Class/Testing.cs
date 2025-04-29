using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class Testing
    {
        public void Time() 
        {
            // Example: User inputs the year, month, and preferred day
            int year = 2025;                // Input year
            int month = 4;                  // Input month
            string dayInput = "Tuesday";    // User chooses the day (e.g., "Tuesday")

            // Parse the day input to a DayOfWeek enum
            DayOfWeek chosenDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayInput);

            // Get all occurrences of the chosen day in the specified month
            List<DateTime> chosenDays = GetDaysInMonth(year, month, chosenDay);

            // Database connection string (update for your setup)
            string connectionString = "YourDatabaseConnectionStringHere";

            // Insert each day into the Scheduling Table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (DateTime day in chosenDays)
                {
                    string query = "INSERT INTO Scheduling (StudentID, TutorID, ScheduledDate, StartTime, EndTime) " +
                                   "VALUES (@StudentID, @TutorID, @ScheduledDate, @StartTime, @EndTime)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@StudentID", 1);  // Example student ID
                        command.Parameters.AddWithValue("@TutorID", 1);    // Example tutor ID
                        command.Parameters.AddWithValue("@ScheduledDate", day);
                        command.Parameters.AddWithValue("@StartTime", "09:00");
                        command.Parameters.AddWithValue("@EndTime", "10:00");

                        command.ExecuteNonQuery(); // Execute the query
                    }
                }
            }

            Console.WriteLine($"All {dayInput}s in {month}/{year} have been scheduled successfully!");
        }

        static List<DateTime> GetDaysInMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            List<DateTime> days = new List<DateTime>();
            DateTime date = new DateTime(year, month, 1);

            // Find the first occurrence of the chosen day in the month
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            // Add all occurrences of the chosen day to the list
            while (date.Month == month)
            {
                days.Add(date); // Add the day to the list
                date = date.AddDays(7); // Move to the next occurrence
            }

            return days;
        }
    }
}
