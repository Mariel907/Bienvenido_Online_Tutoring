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
    public partial class EFAddStudent : Form
    {
        public EFAddStudent()
        {
            InitializeComponent();
        }

        private void G2TxbxFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void G2CmbxPreferredSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G2CmbxPreferredSubjects.SelectedValue != null)
            {
                MSubjects Sub = G2CmbxPreferredSubjects.SelectedItem as MSubjects;
                string selectedGenre = Sub.SubjectName.ToString();
                string currentText = G2TxbxPreferredSubjects.Text;

                if (currentText.Length > 0) G2TxbxPreferredSubjects.Text = currentText + ", " + selectedGenre;
                else G2TxbxPreferredSubjects.Text = selectedGenre;
            }
        }

        private void EFAddStudent_Load(object sender, EventArgs e)
        {
            G2CmbxPreferredSubjects.SelectedIndexChanged -= G2CmbxPreferredSubjects_SelectedIndexChanged;
            var Sub = CFSubjects.Subjects();
            G2CmbxPreferredSubjects.DataSource = Sub;
            G2CmbxPreferredSubjects.DisplayMember = "SubjectName";
            G2CmbxPreferredSubjects.ValueMember = "SubID";
            G2CmbxPreferredSubjects.Text = string.Empty;

            G2CmbxPreferredSubjects.SelectedIndexChanged += G2CmbxPreferredSubjects_SelectedIndexChanged;
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MStudent student = new MStudent();
                student.Firstname = G2TxbxFirstname.Text;
                student.Lastname = G2TxbxLastname.Text;
                student.PrefferedSubjects = G2TxbxPreferredSubjects.Text;
                student.ContactDetails = G2TxbxContactDetails.Text;

                CStudents students = new CStudents();
                students.Insert(student);
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
            G2TxbxPreferredSubjects.Text = string.Empty;
            G2TxbxContactDetails.Text = string.Empty;
        }
    }
}
