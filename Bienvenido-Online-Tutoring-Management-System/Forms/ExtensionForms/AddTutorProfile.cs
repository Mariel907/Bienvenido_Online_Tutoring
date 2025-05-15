using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            if (currentText.Length > 0) G2TxbxDaysAvailable.Text = currentText + ", " + selectedGenre;
            else G2TxbxDaysAvailable.Text = selectedGenre;
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> selectedExpertise = new List<string>();

                foreach(var item in LstBxExpertise.SelectedItems)
                    selectedExpertise.Add(item.ToString());

                MTutorProfile mTutor = new MTutorProfile();
                mTutor.Firstname = G2TxbxFirstname.Text;
                mTutor.lastname = G2TxbxLastname.Text;
                mTutor.Expertise = string.Join(", ", selectedExpertise);
                mTutor.HourlyRate = Convert.ToDecimal(G2TxbxHourlyRate.Text);
                mTutor.StartTime = Convert.ToDateTime(DTPStartTime.Text).TimeOfDay;
                mTutor.EndTime = Convert.ToDateTime(DTPEndTime.Text).TimeOfDay;
                mTutor.DaysAvailable = G2TxbxDaysAvailable.Text;

                CTutorProfile CTutor = new CTutorProfile();
                CTutor.Insert(mTutor);

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
