using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
            Visible_();
            ShowSubjects();
        }
        private void ShowSubjects()
        {
            LstBxExpertise.Items.Clear();
            foreach (var subject in CFSubjects.Subjects())
            {
                LstBxExpertise.Items.Add(subject.SubjectName);
            }
        }

        private void G2CmbxDaysAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G2CmbxDaysAvailable.SelectedItem == null)
                return;
            string selectedGenre = G2CmbxDaysAvailable.SelectedItem.ToString();
            string currentText = G2TxbxDaysAvailable.Text;

            if (currentText.Split(',').Select(x => x.Trim()).Contains(selectedGenre))
                return;

            G2TxbxDaysAvailable.Text = currentText.Length > 0 ? currentText + ", " + selectedGenre : selectedGenre;

            G2TxbxDaysAvailable.SelectionStart = G2TxbxDaysAvailable.Text.Length;
            G2TxbxDaysAvailable.SelectionLength = 0;
            G2TxbxDaysAvailable.Focus();
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFieldsIsEmpty())
                {
                    return;
                }

                List<string> selectedExpertise = new List<string>();

                foreach (var item in LstBxExpertise.SelectedItems)
                    selectedExpertise.Add(item.ToString());

                MTutorProfile mTutor = new MTutorProfile();
                mTutor.Firstname = G2TxbxFirstname.Text;
                mTutor.lastname = G2TxbxLastname.Text;
                mTutor.Expertise = string.Join(", ", selectedExpertise);
                mTutor.HourlyRate = Convert.ToDecimal(G2TxbxHourlyRate.Text);
                mTutor.StartTime = Convert.ToDateTime(DTPStartTime.Text).TimeOfDay;
                mTutor.EndTime = Convert.ToDateTime(DTPEndTime.Text).TimeOfDay;
                mTutor.DaysAvailable = G2TxbxDaysAvailable.Text;
                mTutor.Email = G2TxbxEmail.Text;

                DateTime STime = DateTime.Today.Add(mTutor.StartTime);
                DateTime ETime = DateTime.Today.Add(mTutor.EndTime);

                if (ETime <= STime)
                    ETime = ETime.AddDays(1);

                TimeSpan duration = ETime - STime;

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Insert(mTutor, selectedExpertise, STime, ETime);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EmptyFields();
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
            G2TxbxEmail.Text = string.Empty;
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

        private void G2TxbxHourlyRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void G2TxbxFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void LstBxExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblExpertise.Visible = false;
        }

        private void DTPEndTime_ValueChanged(object sender, EventArgs e)
        {
            LblEndTime.Visible = false;
            LblStartTime.Visible = false;
        }

        private void DTPStartTime_ValueChanged(object sender, EventArgs e)
        {
            LblEndTime.Visible = false;
            LblStartTime.Visible = false;
        }

        private void G2TxbxLastName_TextChanged_1(object sender, EventArgs e)
        {
            LblLastname.Visible = false;
        }

        private void G2TxbxDaysAvailable_TextChanged_1(object sender, EventArgs e)
        {
            LblDaysAvailable.Visible = false;
        }

        private void G2TxbxHourlyRte_TextChanged_1(object sender, EventArgs e)
        {
            LblHourlyRate.Visible = false;
        }

        private void G2TxbxFirstname_TextChanged_1(object sender, EventArgs e)
        {
            LblFirstname.Visible = false;
        }

        private void G2TxbxEmail_TextChanged(object sender, EventArgs e)
        {
            LblEmail.Visible = false;
        }
    }
}
