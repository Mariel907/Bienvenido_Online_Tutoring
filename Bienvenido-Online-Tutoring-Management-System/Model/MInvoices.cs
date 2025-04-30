using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class MInvoices
    {
        public int InvoiceID { get; set; }
        public int TutorID { get; set; }
        public int StudentID { get; set; }
        public decimal TotalHours { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; }
        public string  Subject { get; set; }
        public int SessionID { get; set; }


    }
}
