using System;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MSession
    {
        public int SessionID { get; set; }
        public int TutorID { get; set; }
        public string StudFullname { get; set; }
        public string Subject { get; set; }
        public string TutorFullname { get; set; }
        public int StudentID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime SessionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
