using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EditTutorProfile : Form
    {
        private Dashboard _dashboard;
        private FormManager form = new FormManager();
        private MTutorProfile _MTutorProfile;

        public EditTutorProfile(Dashboard dashboard, MTutorProfile mTutor)
        {
            InitializeComponent();
            _dashboard = dashboard;
            _MTutorProfile = mTutor;
            ObjectReference();
        }

        private void ObjectReference()
        {
            G2TxbxFirstname.Text = _MTutorProfile.Firstname;
            G2TxbxLastname.Text = _MTutorProfile.lastname;
            G2TxbxDaysAvailable.Text = _MTutorProfile.DaysAvailable;
            G2TxbxHourlyRate.Text = _MTutorProfile.HourlyRate.ToString("F2");
            DTPStartTime.Value = DateTime.Today.Add(_MTutorProfile.StartTime);
            DTPEndTime.Value = DateTime.Today.Add(_MTutorProfile.EndTime);
            LblAvailbalityID.Text = _MTutorProfile.AvailabilityID.ToString();
            LblTutorID.Text = _MTutorProfile.TutorID.ToString();

            ExpertiseCmbx();

            string[] selectedExpertise = _MTutorProfile.Expertise.Split(',')
                                   .Select(e => e.Trim()) 
                                   .ToArray();

            var itemsToSelect = new List<int>();

            foreach (var item in LstBxExpertise.Items)
            {
                if (selectedExpertise.Any(e => e.Equals(item.ToString().Trim(), StringComparison.OrdinalIgnoreCase)))
                    itemsToSelect.Add(LstBxExpertise.Items.IndexOf(item)); 
            }

            foreach (var index in itemsToSelect)
                LstBxExpertise.SetSelected(index, true);

            LstBxExpertise.Refresh(); 
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

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            AddTutorProfile Add = new AddTutorProfile(_dashboard);
            form.OpenForm(Add, _dashboard.Panel);
        }

        private void G2BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> selectedItem = new List<string>();

                foreach(var item in LstBxExpertise.SelectedItems)
                    selectedItem.Add(item.ToString());

                MTutorProfile mTutor = new MTutorProfile();
                mTutor.Firstname = G2TxbxFirstname.Text;
                mTutor.lastname = G2TxbxLastname.Text;
                mTutor.Expertise = string.Join(", ", selectedItem);
                mTutor.HourlyRate = Convert.ToDecimal(G2TxbxHourlyRate.Text);
                mTutor.StartTime = Convert.ToDateTime(DTPStartTime.Text).TimeOfDay;
                mTutor.EndTime = Convert.ToDateTime(DTPEndTime.Text).TimeOfDay;
                mTutor.DaysAvailable = G2TxbxDaysAvailable.Text;
                mTutor.TutorID = Convert.ToInt32(LblTutorID.Text);
                mTutor.AvailabilityID = Convert.ToInt32(LblAvailbalityID.Text);

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Update(mTutor, selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmptyFields();
        }
        private void EmptyFields()
        {
            G2TxbxFirstname.Text = string.Empty;
            G2TxbxLastname.Text = string.Empty;
            G2TxbxDaysAvailable.Text = string.Empty;
            G2TxbxHourlyRate.Text = string.Empty;
            DTPStartTime.Value = DateTime.Now;
            DTPEndTime.Value = DateTime.Now;
            G2CmbxDaysAvailable.SelectedIndex = -1;
            LstBxExpertise.ClearSelected();
        }
        private void EditTutorProfile_Load(object sender, EventArgs e)
        {
        }
        private void ExpertiseCmbx()
        {
            LstBxExpertise.Items.Clear();
            foreach (var sub in CFSubjects.Subjects())
            {
                LstBxExpertise.Items.Add(sub.SubjectName);
            }
        }

        private void LstBxExpertise_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color selectionColor = isSelected ? Color.FromArgb(188, 184, 177) : e.BackColor;
            Color textColor = Color.FromArgb(28, 42, 68);

            using (SolidBrush backgroundBrush = new SolidBrush(selectionColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                e.Graphics.DrawString(LstBxExpertise.Items[e.Index].ToString(), e.Font, textBrush, RestoreBounds.Left + 20, e.Bounds.Top);
            }
            e.DrawFocusRectangle();
        }
    }
}
