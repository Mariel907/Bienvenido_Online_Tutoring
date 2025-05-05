using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
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
    public partial class Tester : Form
    {
        private MTutorProfile mt;
        public Tester(MTutorProfile mt)
        {
            InitializeComponent();
            this.mt = mt;
            FillInFields();
        }
        private void FillInFields()
        {
            LblID.Text = mt.TutorID.ToString();
            Cmbx.Text = mt.TutorName;
        }
        private void Tester_Load(object sender, EventArgs e)
        {
            TutorName();
        }
        private void TutorName()
        {
            Cmbx.DataSource = CEarnings.TutorShow();
            Cmbx.DisplayMember = "TutorName";
            Cmbx.ValueMember = "TutorID";
        }

        private void G2CmbxTutorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void G2CmbxTutorName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Cmbx.SelectedValue != null)
            {
                MTutorProfile mt = Cmbx.SelectedItem as MTutorProfile;
                LblID.Text = mt.TutorID.ToString();
            }
        }
    }
}
