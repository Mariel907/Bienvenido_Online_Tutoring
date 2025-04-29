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
    public partial class AddTutorProfile : Form
    {
        private FormManager form = new FormManager();
        private Dashboard _dashboard;
        private MTutorProfile tutor = new MTutorProfile();
        public AddTutorProfile(Dashboard dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
        }

        private void G2BtnEdit_Click(object sender, EventArgs e)
        {
            EditTutorProfile Edit = new EditTutorProfile(_dashboard, tutor);
            form.OpenForm(Edit, _dashboard.Panel);

        }

        private void AddTutorProfile_Load(object sender, EventArgs e)
        {
            var Subject = CFSubjects.Subjects();
            G2CmbxExpertise.DataSource = Subject;
            G2CmbxExpertise.DisplayMember = "SubjectName";
            G2CmbxExpertise.ValueMember = "SubID";
            G2TxbxExpertise.Text = string.Empty;

        }

        private void G2CmbxDaysAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G2CmbxDaysAvailable.SelectedItem == null)
                return;
            string selectedGenre = G2CmbxDaysAvailable.SelectedItem.ToString();
            string currentText = G2TxbxDaysAvailable.Text;

            if (currentText.Length > 0) G2TxbxDaysAvailable.Text = currentText + ", " + selectedGenre;
            else G2TxbxDaysAvailable.Text = selectedGenre;
        }
        private void G2TestingExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G2CmbxExpertise.SelectedValue != null)
            {
                MSubjects Sub = G2CmbxExpertise.SelectedItem as MSubjects;
                string selectedGenre = Sub.SubjectName.ToString();
                string currentText = G2TxbxExpertise.Text;

                if (currentText.Length > 0) G2TxbxExpertise.Text = currentText + ", " + selectedGenre;
                else G2TxbxExpertise.Text = selectedGenre;
            }
        }

        private void G2BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MTutorProfile mTutor = new MTutorProfile();
                mTutor.Firstname = G2TxbxFirstname.Text;
                mTutor.lastname = G2TxbxLastname.Text;
                mTutor.Expertise = G2TxbxExpertise.Text;
                mTutor.HourlyRate = Convert.ToDecimal(G2TxbxHourlyRate.Text);
                mTutor.StartTime = Convert.ToDateTime(DTPStartTime.Text).TimeOfDay;
                mTutor.EndTime = Convert.ToDateTime(DTPEndTime.Text).TimeOfDay;
                mTutor.DaysAvailable = G2TxbxDaysAvailable.Text;

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Insert(mTutor);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmptyFields();
        }
        private void EmptyFields()
        {
            G2TxbxFirstname.Text = string.Empty;
            G2TxbxLastname.Text = string.Empty;
            G2TxbxExpertise.Text = string.Empty;
            G2TxbxDaysAvailable.Text = string.Empty;
            G2TxbxHourlyRate.Text = string.Empty;
            DTPStartTime.Value = DateTime.Now;
            DTPEndTime.Value = DateTime.Now;
        }

    }
}
