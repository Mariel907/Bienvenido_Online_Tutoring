using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MStudent
    {
        public int StudentID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ContactDetails { get; set; }
        public string PrefferedSubjects { get; set; }
        public string StudentName { get; set; }
        public decimal Cash { get; set; }
        public decimal Changed { get; set; }
    }
}
