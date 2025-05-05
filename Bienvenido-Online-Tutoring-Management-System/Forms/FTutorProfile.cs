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
        private CTutorProfile _CTutorProfile = new CTutorProfile();


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
            MTutor.Firstname = selectedRow.Cells["_Firstname"].Value.ToString();
            MTutor.lastname = selectedRow.Cells["_Lastname"].Value.ToString();
            MTutor.Expertise = selectedRow.Cells["_Expertise"].Value.ToString();
            MTutor.HourlyRate = Convert.ToDecimal(selectedRow.Cells["_HourlyRate"].Value.ToString());
            MTutor.AvailabilityID = Convert.ToInt32(selectedRow.Cells["_AvailabilityID"].Value.ToString());
            MTutor.StartTime = Convert.ToDateTime(selectedRow.Cells["_StartTime"].Value.ToString()).TimeOfDay;
            MTutor.EndTime = Convert.ToDateTime(selectedRow.Cells["_EndTime"].Value.ToString()).TimeOfDay;
            MTutor.DaysAvailable = selectedRow.Cells["_DaysAvailable"].Value.ToString();

            EditTutorProfile edit= new EditTutorProfile(_dashboard, MTutor);
            form.OpenForm(edit, _dashboard.Panel);
        }

        private void G2TxbxSearch_TextChanged(object sender, EventArgs e)
        {
            string Txbx = G2TxbxSearch.Text;
            _CTutorProfile.Search(Txbx, DGVTutor);
        }

        private void DGVTutor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is FEarningsTutor) return;
            }
            DataGridViewRow SelectedRow = DGVTutor.SelectedRows[0];
            MTutorProfile mt = new MTutorProfile();
            mt.TutorID = Convert.ToInt32(SelectedRow.Cells["_TutorID"].Value.ToString());
            mt.TutorName = SelectedRow.Cells["TutorName"].Value.ToString();

            FEarningsTutor earnings = new FEarningsTutor(mt);
            earnings.Show();
        }
    }
}
