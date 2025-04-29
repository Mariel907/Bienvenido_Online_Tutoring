using Bienvenido_Online_Tutoring_Management_System.Class;
using Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms;
using Bienvenido_Online_Tutoring_Management_System.Model;
using Guna.UI2.WinForms;
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
    public partial class Dashboard : Form
    {
        private FormManager form = new FormManager();
        public Panel Panel { get{ return PnlDashboard; } }
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Form_Click(object sender, EventArgs e)
        {
            if(sender is Guna2Button button)
            {
                SetButtonNames();
                UpdateColor(button.Name);
                OpenForm(button.Name);
            }
        }
        private void SetButtonNames()
        {
            G2BtnPayments.Name = "Payments";
            G2BtnStudents.Name = "Students";
            G2BtnTransaction.Name = "Transaction";
            G2BtnTutorsProfile.Name = "TutorProfile";
            G2BtnDashboard.Name = "Dashboard";
            G2Subjects.Name = "Subjects";
        }

        private void UpdateColor(string ActiveButton)
        {
            Color InActive = Color.FromArgb(250, 249, 246);
            Color Active = Color.FromArgb(188, 184, 177);

            G2BtnDashboard.FillColor = ActiveButton == "Dashboard" ? Active : InActive;
            G2BtnPayments.FillColor = ActiveButton == "Payments" ? Active : InActive;
            G2BtnStudents.FillColor = ActiveButton == "Students" ? Active : InActive;
            G2BtnTransaction.FillColor = ActiveButton == "Transaction" ? Active : InActive;
            G2BtnTutorsProfile.FillColor = ActiveButton == "TutorProfile" ? Active : InActive;
            G2Subjects.FillColor = ActiveButton == "Subjects" ? Active : InActive;
        }

        private void OpenForm(string ButtonName)
        {
            switch (ButtonName)
            {
                case "Dashboard":
                    LblTitle.Text = "Dashboard";
                    FDashboard fDashboard = new FDashboard();
                    form.OpenForm(fDashboard, PnlDashboard);
                    break;
                case "Payments":
                    LblTitle.Text = "Payments";
                    FPayments fPayments = new FPayments();
                    form.OpenForm(fPayments, PnlDashboard);
                    break;
                case "Students":
                    LblTitle.Text = "Students";
                    FStudents fStudents = new FStudents(this);
                    form.OpenForm(fStudents, PnlDashboard);
                    break;
                case "Transaction":
                    LblTitle.Text = "Transaction";
                    FTransaction fTransaction = new FTransaction(this);
                    form.OpenForm(fTransaction, PnlDashboard);
                    break;
                case "TutorProfile":
                    LblTitle.Text = "TutorProfile";
                    MTutorProfile tutor = new MTutorProfile();  
                    EditTutorProfile edit = new EditTutorProfile(this, tutor);
                    FTutorProfile fTutorProfile = new FTutorProfile(edit, this);
                    form.OpenForm(fTutorProfile, PnlDashboard);
                    break;
                case "Subjects":
                    LblTitle.Text = "Subjects";
                    FSubjects fSubjects = new FSubjects();
                    form.OpenForm(fSubjects, PnlDashboard);
                    break;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LblTitle.Text = "Dashboard";
            FDashboard fDashboard = new FDashboard();
            form.OpenForm(fDashboard, PnlDashboard);
        }
    }
}
