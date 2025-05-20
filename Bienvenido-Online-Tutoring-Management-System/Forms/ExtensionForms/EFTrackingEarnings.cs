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
    public partial class EFTrackingEarnings : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        private MTutorProfile _profile;
        public EFTrackingEarnings(MTutorProfile Tutor)
        {
            InitializeComponent();
            _profile = Tutor;
        }
        private void FilinFields()
        {
            LblID.Text = _profile.TutorID.ToString();
            G2CmbxTutorName.Text = _profile.TutorName;
            DTPStartTime.Value = _profile.SDate;
            DTPEndTime.Value = _profile.EDate;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void EFTrackingEarnings_Load(object sender, EventArgs e)
        {
            TutorName_();
            FilinFields();
            ShowBindingSource();
        }
        private void TutorName_()
        {
            G2CmbxTutorName.DataSource = CEarnings.TutorShow();
            G2CmbxTutorName.DisplayMember = "TutorName";
            G2CmbxTutorName.ValueMember = "TutorID";
        }

        private void ShowBindingSource()
        {
            DateTime SDate = Convert.ToDateTime(DTPStartTime.Value);
            DateTime EDate = Convert.ToDateTime(DTPEndTime.Value);
            _bindingSource.DataSource = CTrackingEarnings.ShowEarnings(LblID.Text, SDate, EDate);
            DGV.DataSource = _bindingSource;
        }

        private void G2CmbxTutorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(G2CmbxTutorName.SelectedValue != null)
            {
                MTutorProfile ss = G2CmbxTutorName.SelectedItem as MTutorProfile;
                LblID.Text = ss.TutorID.ToString();   
            }
            ShowBindingSource();
        }

        private void DTPStartTime_ValueChanged(object sender, EventArgs e)
        {
            ShowBindingSource();
        }

        private void DTPEndTime_ValueChanged(object sender, EventArgs e)
        {
            ShowBindingSource();
        }
        //private void StatusChecked()
        //{
        //string LblId = LblID.Text;
        //List<string> checked_ = new List<string>();

        //if (G2CHKDone.Checked) checked_.Add("Done");
        //if (G2CHKScheduled.Checked) checked_.Add("Scheduled");
        //if (G2CHKOnGoing.Checked) checked_.Add("OnGoing");

        //CEarnings earnings = new CEarnings();
        //earnings.SearchCmbx(DGV, LblId, checked_);
        //}

        //private void Status_CheckedChanged(object sender, EventArgs e)
        //{
        //    StatusChecked();
        //}
    }
}
