using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class Slots
    {
        public Dictionary<DateTime, List<TimeSpan>> GroupedTimeslots { get; set; }
    }
}
