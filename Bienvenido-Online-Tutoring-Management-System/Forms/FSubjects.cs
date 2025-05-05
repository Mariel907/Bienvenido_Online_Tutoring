using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Model;
using System;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    public partial class FSubjects : Form
    {
        private CFSubjects _fsubjects = new CFSubjects();
        private MSubjects sub = new MSubjects();
        
        public FSubjects()
        {
            InitializeComponent();
        }

        private void FSubjects_Load(object sender, EventArgs e)
        {
            RefreshedDGV();
        }
        private void RefreshedDGV()
        {
            DGVSubjects.DataSource = CFSubjects.Subjects();
        }
        private void G2BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sub.SubjectName = G2TxbxAdd.Text;
                _fsubjects.ExecuteAction("Add", sub);
                RefreshedDGV();

                G2TxbxAdd.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = DGVSubjects.SelectedRows[0];
            G2TxbxEdit.Text = selectedRow.Cells["SubjectName"].Value.ToString();
            LblID.Text = selectedRow.Cells["SubID"].Value.ToString();
        }

        private void G2BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sub.SubID = Convert.ToInt32(LblID.Text);
                sub.SubjectName = G2TxbxEdit.Text;
                _fsubjects.ExecuteAction("Update", sub);

                _fsubjects.RefreshInSearch(LblID.Text, DGVSubjects);

                G2TxbxEdit.Text = string.Empty;
                LblID.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void G2TxbxSearch_TextChanged(object sender, EventArgs e)
        {
            _fsubjects.SearchSubject(G2TxbxSearch.Text, DGVSubjects);
        }
    }
}
