using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MTutorProfile
    {
        public int TutorID { get; set; }
        public string TutorName { get; set; }
        public string Expertise { get; set; }
        public decimal HourlyRate { get; set; }
        public int AvailabilityID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DaysAvailable { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public string Email { get; set; }
    }
}
