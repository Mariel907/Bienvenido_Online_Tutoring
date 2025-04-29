using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Class
{
    public class FormManager
    {
        public void OpenForm(Form form,  Panel panel )
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            panel.Controls.Add( form );
            form.Show();
        }
    }
}
