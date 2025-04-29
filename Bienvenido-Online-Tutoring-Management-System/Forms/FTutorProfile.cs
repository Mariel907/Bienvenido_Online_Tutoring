using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms;
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

namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    public partial class FTutorProfile : Form
    {
        private EditTutorProfile _AddEditTutorProfile;
        private FormManager form = new FormManager();
        private Dashboard _dashboard;


        public FTutorProfile(EditTutorProfile addEditTutorProfile, Dashboard dashboard)
        {
            InitializeComponent();
            _AddEditTutorProfile = addEditTutorProfile;
            _dashboard = dashboard;
        }

        private void FTutorProfile_Load(object sender, EventArgs e)
        {
            RefreshedDgv();
        }
        private void RefreshedDgv()
        {
            DGVTutor.DataSource = CTutorProfile.Tutors();
        }


        private void DGVTutor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void G2BtnUpdate_Click(object sender, EventArgs e)
        {
            AddTutorProfile add = new AddTutorProfile(_dashboard);
            form.OpenForm(add, _dashboard.Panel);
        }

        private void G2BtnEdit_Click(object sender, EventArgs e)
        {
            MTutorProfile MTutor = new MTutorProfile();
            DataGridViewRow selectedRow = DGVTutor.SelectedRows[0];

            MTutor.TutorID = Convert.ToInt32(selectedRow.Cells["TutorID"].Value.ToString());
            MTutor.Firstname = selectedRow.Cells["Firstname"].Value.ToString();
            MTutor.lastname = selectedRow.Cells["Lastname"].Value.ToString();
            MTutor.Expertise = selectedRow.Cells["Expertise"].Value.ToString();
            MTutor.HourlyRate = Convert.ToDecimal(selectedRow.Cells["HourlyRate"].Value.ToString());
            MTutor.AvailabilityID = Convert.ToInt32(selectedRow.Cells["AvailabilityID"].Value.ToString());
            MTutor.StartTime = Convert.ToDateTime(selectedRow.Cells["StartTime"].Value.ToString()).TimeOfDay;
            MTutor.EndTime = Convert.ToDateTime(selectedRow.Cells["EndTime"].Value.ToString()).TimeOfDay;
            MTutor.DaysAvailable = selectedRow.Cells["DaysAvailable"].Value.ToString();

            EditTutorProfile edit= new EditTutorProfile(_dashboard, MTutor);
            form.OpenForm(edit, _dashboard.Panel);
        }
    }
}
