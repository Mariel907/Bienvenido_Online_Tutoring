using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class EFAddStudent : Form
    {
        public EFAddStudent()
        {
            InitializeComponent();
        }

        private void EFAddStudent_Load(object sender, EventArgs e)
        {
            ShowSubject();
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
    }
}
