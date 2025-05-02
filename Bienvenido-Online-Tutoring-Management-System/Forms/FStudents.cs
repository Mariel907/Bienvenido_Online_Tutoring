using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms;
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

namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    public partial class FStudents : Form
    {
        private FormManager form = new FormManager();
        private Dashboard _Dashboard;
        private CStudents _Students = new CStudents();
        public FStudents(Dashboard dashboard)
        {
            InitializeComponent();
            _Dashboard = dashboard; 
        }

        private void FStudents_Load(object sender, EventArgs e)
        {
            DGVStudent.DataSource = CStudents.Students();
        }

        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            EFAddStudent add = new EFAddStudent();
            form.OpenForm(add, _Dashboard.Panel);
        }

        private void G2BtnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = DGVStudent.SelectedRows[0];
            MStudent student = new MStudent();
            student.Firstname = selectedRow.Cells["Firstname"].Value.ToString();
            student.Lastname = selectedRow.Cells["Lastname"].Value.ToString();
            student.PrefferedSubjects = selectedRow.Cells["PrefferedSubjects"].Value.ToString();
            student.ContactDetails = selectedRow.Cells["ContactDetails"].Value.ToString();
            student.StudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value.ToString());

            EFEditStudents edit = new EFEditStudents(student);
            form.OpenForm(edit, _Dashboard.Panel);
        }

        private void G2TxbxSearch_TextChanged(object sender, EventArgs e)
        {
            string Txbx = G2TxbxSearch.Text;
            _Students.Search(Txbx, DGVStudent);
        }
    }
}
