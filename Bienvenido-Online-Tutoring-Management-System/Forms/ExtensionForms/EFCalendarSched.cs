using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EFCalendarSched : Form
    {
        public EFCalendarSched(string SessionDetails, string status)
        {
            InitializeComponent();
            LblStatus.Text = SessionDetails;

            switch(status)
            {
                case "Done":
                    this.BackColor = Color.FromArgb(255, 235, 230);
                    break;
                case "Scheduled":
                    this.BackColor = Color.FromArgb(255, 255, 204);
                    break;
                case "OnGoing":
                    this.BackColor = Color.FromArgb(204, 255, 204);
                    break;
                default:
                    this.BackColor = Color.White;
                    break;
            }
        }

        private void EFCalendarSched_Load(object sender, EventArgs e)
        {

        }
    }
}
