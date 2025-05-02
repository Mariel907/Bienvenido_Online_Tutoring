using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms
{
    public partial class FTransaction : Form
    {
        private Dashboard _dashboard;
        private FormManager _FormManager = new FormManager();
        private CTransaction transaction = new CTransaction();
        public FTransaction(Dashboard dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
        }

        private void G2BtnSchedule_Click(object sender, EventArgs e)
        {
            EFSelectStudent select = new EFSelectStudent(_dashboard);
            _FormManager.OpenForm(select, _dashboard.Panel);
        }

        private void FTransaction_Load(object sender, EventArgs e)
        {
            DGVScheduled.DataSource = CSchedule.Transaction();
            ShowStudentCMBX();
        }
        private void ShowStudentCMBX()
        {
            G2CmbxStudentName.DataSource = CTransaction.StudentsName();
            G2CmbxStudentName.DisplayMember = "StudentName";
        }
        private void G2CmbxStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cmbx = G2CmbxStudentName.Text;

            transaction.Search(Cmbx, DGVScheduled);
        }

        private void DGVScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = DGVScheduled.Rows[e.RowIndex];
            string status = row.Cells["Status"].Value?.ToString();

            switch (status)
            {
                case "Scheduled":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                    break;
                case "OnGoing":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153);
                    break;
                case "Done":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                    break;
                case "Cancel":
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 194, 102);
                    break;
                case "Draft":
                    //row.DefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153);
                    break;
            }
        }
    }
}
