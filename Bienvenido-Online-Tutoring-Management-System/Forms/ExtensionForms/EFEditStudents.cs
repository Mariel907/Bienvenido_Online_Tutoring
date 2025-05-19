using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EFEditStudents : Form
    {
        private MStudent _stud;
        private CStudents _cStudents = new CStudents();
        public EFEditStudents(MStudent stud)
        {
            InitializeComponent();
            _stud = stud;
            AssignValue();
        }
        private void AssignValue()
        {
            G2TxbxFirstname.Text = _stud.Firstname;
            G2TxbxLastname.Text = _stud.Lastname;
            G2TxbxContactDetails.Text = _stud.ContactDetails;
            LblStudentID.Text = _stud.StudentID.ToString();

            ShowSubject();

            string[] selectedExpertise = _stud.PrefferedSubjects.Split(',')
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

        private void EFEditStudents_Load(object sender, EventArgs e)
        {
            Visible_();
        }
        private void Visible_()
        {
            LblFirstname.Visible = false;
            LblLastname.Visible = false;
            LblEmail.Visible = false;
            LblSubject.Visible = false;
        }
        private bool IsValidEmail()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(G2TxbxContactDetails.Text, pattern);
        }
        private bool IsFieldEmpty()
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(G2TxbxFirstname.Text))
            {
                LblFirstname.Visible = true;
                hasError = true;
            }
            else
                LblFirstname.Visible = false;

            if (string.IsNullOrEmpty(G2TxbxLastname.Text))
            {
                LblLastname.Visible = true;
                hasError = true;
            }
            else
                LblLastname.Visible = false;

            if(string.IsNullOrEmpty(G2TxbxContactDetails.Text) || !IsValidEmail())
            {
                LblEmail.Visible = true;
                hasError = true;
            }
            else
                LblEmail.Visible = false;

            if(LstBxExpertise.SelectedItems.Count == 0)
            {
                LblEmail.Visible = true;
                hasError = true;
            }
            else
                LblEmail.Visible= false;

                return hasError;
        }
        private void ShowSubject()
        {
            LstBxExpertise.Items.Clear();

            foreach(var sub in  CFSubjects.Subjects())
                LstBxExpertise.Items.Add(sub.SubjectName);
        }
        private void G2BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFieldEmpty()) return;

                List<string> selectedItems = new List<string>();

                foreach(var item in LstBxExpertise.SelectedItems)
                    selectedItems.Add(item.ToString());

                MStudent student = new MStudent();
                student.Firstname = G2TxbxFirstname.Text;
                student.Lastname = G2TxbxLastname.Text;
                student.PrefferedSubjects = string.Join(", ",selectedItems);
                student.ContactDetails = G2TxbxContactDetails.Text;
                student.StudentID = Convert.ToInt32(LblStudentID.Text);

                _cStudents.Update(student);
                EmptyFields();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmptyFields()
        {
            G2TxbxFirstname.Text = string.Empty;
            G2TxbxLastname.Text = string.Empty;
            G2TxbxContactDetails.Text = string.Empty;
            LblStudentID.Text = string.Empty;
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

        private void LstBxExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblSubject.Visible = false;
        }

        private void G2TxbxLastname_TextChanged(object sender, EventArgs e)
        {
            LblLastname.Visible = false;
        }

        private void G2TxbxContactDetails_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(G2TxbxContactDetails.Text) || !IsValidEmail())
            {
                LblEmail.Visible = true;
                return;
            }
            else
                LblEmail.Visible = false;
        }

        private void G2TxbxFirstname_TextChanged(object sender, EventArgs e)
        {
            LblFirstname.Visible = false;
        }
    }
}
