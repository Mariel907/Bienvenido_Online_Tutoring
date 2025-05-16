using System;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MSession
    {
        public int SessionID { get; set; }
        public int TutorID { get; set; }
        public string StudName { get; set; }
        public string Subject { get; set; }
        public string TutorName { get; set; }
        public int StudentID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime SessionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal HourlyRate { get; set; }
        public string Status { get; set; }
        public string StatusBill { get; set; }
        public int InvoiceID { get; set; }
        public decimal TotalHours { get; set; }
        public string ContactDetails { get; set; }

        public override string ToString()
        {
            return $"{StudName} | {TutorName} | {Subject} - {StartTime} to {EndTime}";
        }
    }
}
