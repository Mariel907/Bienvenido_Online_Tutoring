using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using Guna.UI2.WinForms;
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
    public partial class EditTutorProfile : Form
    {
        private FTutorProfile _FTutorProfile;
        private Dashboard _dashboard;
        private FormManager form = new FormManager();
        private MTutorProfile _MTutorProfile;

        public EditTutorProfile(Dashboard dashboard, MTutorProfile mTutor)
        {
            InitializeComponent();
            _dashboard = dashboard;
            _MTutorProfile = mTutor;
            _FTutorProfile = new FTutorProfile(this, _dashboard);

            ObjectReference();
        }

        private void ObjectReference()
        {
            G2TxbxFirstname.Text = _MTutorProfile.Firstname;
            G2TxbxLastname.Text = _MTutorProfile.lastname;
            G2TxbxExpertise.Text = _MTutorProfile.Expertise;
            G2TxbxDaysAvailable.Text = _MTutorProfile.DaysAvailable;
            G2TxbxHourlyRate.Text = _MTutorProfile.HourlyRate.ToString("F2");
            DTPStartTime.Value = DateTime.Today.Add(_MTutorProfile.StartTime);
            DTPEndTime.Value = DateTime.Today.Add(_MTutorProfile.EndTime);
            LblAvailbalityID.Text = _MTutorProfile.AvailabilityID.ToString();
            LblTutorID.Text = _MTutorProfile.TutorID.ToString();
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
        private void RefreshedExpertise()
        {
            
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            AddTutorProfile Add = new AddTutorProfile(_dashboard);
            form.OpenForm(Add, _dashboard.Panel);
        }

        private void G2CmbxExpertise_SelectedIndexChanged(object sender, EventArgs e)
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
                mTutor.TutorID = Convert.ToInt32(LblTutorID.Text);   
                mTutor.AvailabilityID = Convert.ToInt32(LblAvailbalityID.Text);

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Update(mTutor);
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
        private void EditTutorProfile_Load(object sender, EventArgs e)
        {
            ExpertiseCmbx();
        }
        private void ExpertiseCmbx()
        {
            G2CmbxExpertise.SelectedIndexChanged -= G2CmbxExpertise_SelectedIndexChanged;

            G2CmbxExpertise.DataSource = CFSubjects.Subjects();
            G2CmbxExpertise.DisplayMember = "SubjectName";
            G2CmbxExpertise.ValueMember = "SubID";

            G2CmbxExpertise.SelectedIndexChanged += G2CmbxExpertise_SelectedIndexChanged;
        }
    }
}
