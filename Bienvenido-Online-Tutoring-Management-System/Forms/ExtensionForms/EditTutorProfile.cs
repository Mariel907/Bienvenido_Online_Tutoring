using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
        private void Visible_()
        {
            LblFirstname.Visible = false;
            LblLastname.Visible = false;
            LblExpertise.Visible = false;
            LblDaysAvailable.Visible = false;
            LblHourlyRate.Visible = false;
            LblStartTime.Visible = false;
            LblEndTime.Visible = false;
            LblEmail.Visible = false;
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
            G2TxbxEmail.Text = _MTutorProfile.Email;

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
                if (isFieldsIsEmpty()) return;

                List<string> selectedItem = new List<string>();

                foreach (var item in LstBxExpertise.SelectedItems)
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
                mTutor.Email = G2TxbxEmail.Text;

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Update(mTutor, selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmptyFields();
        }
        private bool IsValidEmail()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(G2TxbxEmail.Text, pattern);
        }

        private bool isFieldsIsEmpty()
        {
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(G2TxbxFirstname.Text))
            {
                LblFirstname.Visible = true;
                hasError = true;
            }
            else
                LblFirstname.Visible = false;

            if (string.IsNullOrWhiteSpace(G2TxbxLastname.Text))
            {
                LblLastname.Visible = true;
                hasError = true;
            }
            else
                LblLastname.Visible = false;

            if (string.IsNullOrWhiteSpace(G2TxbxHourlyRate.Text))
            {
                LblHourlyRate.Visible = true;
                hasError = true;
            }
            else
                LblHourlyRate.Visible = false;

            if (string.IsNullOrWhiteSpace(G2TxbxDaysAvailable.Text))
            {
                LblDaysAvailable.Visible = true;
                hasError = true;
            }
            else
                LblDaysAvailable.Visible = false;

            if (DTPStartTime.Value == DTPEndTime.Value)
            {
                LblStartTime.Visible = true;
                LblEndTime.Visible = true;
                hasError = true;
            }
            else
            {
                LblStartTime.Visible = false;
                LblEndTime.Visible = false;
            }

            if (LstBxExpertise.SelectedItems.Count == 0)
            {
                LblExpertise.Visible = true;
                hasError = true;
            }
            else
                LblExpertise.Visible = false;

            if (string.IsNullOrWhiteSpace(G2TxbxEmail.Text) || !IsValidEmail())
            {
                LblEmail.Visible = true;
                hasError = true;
            }
            else
                LblEmail.Visible = false;

            return hasError;
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
            LblTutorID.Text = string.Empty;
            LblAvailbalityID.Text = string.Empty;
            G2TxbxEmail.Text = string.Empty;
        }
        private void EditTutorProfile_Load(object sender, EventArgs e)
        {
            Visible_();
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

        private void DTPEndTime_ValueChanged(object sender, EventArgs e)
        {
            LblEndTime.Visible = false;
        }

        private void G2TxbxDaysAvailable_TextChanged(object sender, EventArgs e)
        {
            LblDaysAvailable.Visible = false;
        }

        private void G2TxbxLastname_TextChanged(object sender, EventArgs e)
        {
            LblLastname.Visible = false;
        }

        private void G2TxbxHourlyRate_TextChanged(object sender, EventArgs e)
        {
            LblHourlyRate.Visible = false;
        }

        private void LstBxExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblExpertise.Visible = false;
        }

        private void DTPStartTime_ValueChanged(object sender, EventArgs e)
        {
            LblStartTime.Visible = false;
        }

        private void G2TxbxFirstname_TextChanged(object sender, EventArgs e)
        {
            LblFirstname.Visible = false;
        }

        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void G2TxbxHourlyRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void G2TxbxEmail_TextChanged(object sender, EventArgs e)
        {
            LblEmail.Visible = false;
        }
    }
}
