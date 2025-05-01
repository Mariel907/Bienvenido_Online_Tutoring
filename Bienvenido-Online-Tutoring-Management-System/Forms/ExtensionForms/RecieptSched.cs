using Bienvenido_Online_Tutoring_Management_System.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class RecieptSched : Form
    {
        private List<MSession> list;
        private MStudent stud;
        public RecieptSched(List<MSession> list, MStudent stud)
        {
            InitializeComponent();
            this.list = list;
            this.stud = stud;
        }

        private void RecieptSched_Load(object sender, EventArgs e)
        {
            RVSchedulePayment.LocalReport.ReportPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Forms\\RDLC\\RecieptSchedule.rdlc");

            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("StudentName", stud.StudentName),
                new ReportParameter("Date", currentDate),
                new ReportParameter("Cash", stud.Cash.ToString("F2")),
                new ReportParameter("Changed", stud.Changed.ToString("F2")),
                new ReportParameter("StudentID", stud.StudentID.ToString())
            };
            RVSchedulePayment.LocalReport.SetParameters(p);

            ReportDataSource ds = new ReportDataSource("DSSchedule", list);
            RVSchedulePayment.LocalReport.DataSources.Clear() ;
            RVSchedulePayment.LocalReport.DataSources.Add(ds);
            this.RVSchedulePayment.RefreshReport();
        }
    }
}
