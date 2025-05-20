using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EFAddStudent : Form
    {
        public EFAddStudent()
        {
            InitializeComponent();
        }
        private void Visible_()
        {
            LblFirstname.Visible = false;
            LblLastname.Visible = false;
            LblEmail.Visible = false;
            LblSubject.Visible = false;
        }
        private void EFAddStudent_Load(object sender, EventArgs e)
        {
            Visible_();
            ShowSubject();
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

            if (string.IsNullOrEmpty(G2TxbxContactDetails.Text) || !IsValidEmail())
            {
                LblEmail.Visible = true;
                hasError = true;
            }
            else
                LblEmail.Visible = false;

            if (LstBxExpertise.SelectedItems.Count == 0)
            {
                LblSubject.Visible = true;
                hasError = true;
            }
            else
                LblSubject.Visible = false;

            return hasError;
        }
        private void ShowSubject()
        {
            LstBxExpertise.Items.Clear();
            foreach (var Subject in CFSubjects.Subjects())
                LstBxExpertise.Items.Add(Subject.SubjectName);
        }
        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFieldEmpty()) return;

                List<string> selectedItem = new List<string>();
                foreach(var Item in LstBxExpertise.SelectedItems) 
                    selectedItem.Add(Item.ToString());

                MStudent student = new MStudent();
                student.Firstname = G2TxbxFirstname.Text;
                student.Lastname = G2TxbxLastname.Text;
                student.PrefferedSubjects = string.Join(",", selectedItem);
                student.ContactDetails = G2TxbxContactDetails.Text;

                CStudents students = new CStudents();
                students.Insert(student, selectedItem);
                EmptyFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EmptyFields()
        {
            G2TxbxFirstname.Text = string.Empty;
            G2TxbxLastname.Text = string.Empty;
            G2TxbxContactDetails.Text = string.Empty;
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

        private void G2TxbxFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void G2TxbxLastname_TextChanged(object sender, EventArgs e)
        {
            LblLastname.Visible = false;
        }

        private void G2TxbxFirstname_TextChanged(object sender, EventArgs e)
        {
            LblFirstname.Visible = false;
        }

        private void G2TxbxContactDetails_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(G2TxbxContactDetails.Text) || !IsValidEmail())
            {
                LblEmail.Visible = true;
            }
            else
                LblEmail.Visible = false; LblEmail.Visible = false; 
        }

        private void LstBxExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblSubject.Visible = false;
        }
    }
}
