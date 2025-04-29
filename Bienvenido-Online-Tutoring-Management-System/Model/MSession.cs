using System;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MSession
    {
        public int SessionID { get; set; }
        public int TutorID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime SessionDate { get; set; }
    }
}
