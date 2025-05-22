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
    public partial class EFSelectStudent : Form
    {
        private FormManager form = new FormManager();
        private Dashboard dashboard;
        private CStudents _CStudents = new CStudents();
        public EFSelectStudent(Dashboard _dashboard)
        {
            InitializeComponent();
            dashboard = _dashboard;
        }

        private void EFSelectStudent_Load(object sender, EventArgs e)
        {
            DGVStudent.DataSource = CStudents.Students();
        }

        private void G2BtnSelect_Click(object sender, EventArgs e)
        {
            MStudent stud = new MStudent();
            DataGridViewRow selectedRow = DGVStudent.SelectedRows[0];
            stud.StudentName = selectedRow.Cells["StudentName"].Value.ToString();
            stud.StudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value.ToString());
            stud.ContactDetails = selectedRow.Cells["ContactDetails"].Value.ToString();

            EFSChedule schedule = new EFSChedule(stud);
            form.OpenForm(schedule, dashboard.Panel);
        }

        private void G2TxbxSearch_TextChanged(object sender, EventArgs e)
        {
            string Txbx = G2TxbxSearch.Text;
            _CStudents.Search(Txbx, DGVStudent);
        }
    }
}
