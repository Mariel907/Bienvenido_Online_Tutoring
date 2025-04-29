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
            G2TxbxPreferredSubjects.Text = _stud.PrefferedSubjects;
            G2TxbxContactDetails.Text = _stud.ContactDetails;
            LblStudentID.Text = _stud.StudentID.ToString();
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

        private void EFEditStudents_Load(object sender, EventArgs e)
        {
            G2CmbxPreferredSubjects.SelectedIndexChanged -= G2CmbxPreferredSubjects_SelectedIndexChanged;
            var Sub = CFSubjects.Subjects();
            G2CmbxPreferredSubjects.DataSource = Sub;
            G2CmbxPreferredSubjects.DisplayMember = "SubjectName";
            G2CmbxPreferredSubjects.ValueMember = "SubID";
            G2CmbxPreferredSubjects.Text = string.Empty;

            G2CmbxPreferredSubjects.SelectedIndexChanged += G2CmbxPreferredSubjects_SelectedIndexChanged;
        }

        private void G2BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MStudent student = new MStudent();
                student.Firstname = G2TxbxFirstname.Text;
                student.Lastname = G2TxbxLastname.Text;
                student.PrefferedSubjects = G2TxbxPreferredSubjects.Text;
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
            G2TxbxPreferredSubjects.Text = string.Empty;
            G2TxbxContactDetails.Text = string.Empty;
            LblStudentID.Text = string.Empty;
        }
    }
}
