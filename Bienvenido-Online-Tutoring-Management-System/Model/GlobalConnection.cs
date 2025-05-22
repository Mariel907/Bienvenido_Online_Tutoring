using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bienvenido_Online_Tutoring_Management_System.Model
{
    public class GlobalConnection
    {
        public static string Connection { get; } = "Data Source=(local);Initial Catalog=BienvenidoOnlineTutoring;Integrated Security=True;TrustServerCertificate=True";

        public static string ConnectionName { get; } = "mcvofszddmfoeybn";
    }
}
