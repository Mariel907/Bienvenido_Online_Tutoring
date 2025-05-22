using Bienvenido_Online_Tutoring_Management_System.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Bienvenido_Online_Tutoring_Management_System.Forms.ExtensionForms
{
    public partial class RecieptSched : Form
    {
        private List<MSession> list;
        private MStudent stud;
        private List<MTutorProfile> tutor;

        public RecieptSched(List<MSession> list, MStudent stud, List<MTutorProfile> tutor)
        {
            InitializeComponent();
            this.list = list;
            this.stud = stud;
            this.tutor = tutor;
        }

        private void RecieptSched_Load(object sender, EventArgs e)
        {
            RVSchedulePayment.LocalReport.ReportPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Forms\\RDLC\\RecieptSchedule.rdlc");

            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("StudentName", stud.StudentName),
                new ReportParameter("Date", currentDate),
                new ReportParameter("Cash", $"₱{stud.Cash.ToString("F2")}"),
                new ReportParameter("Changed", $"₱{stud.Changed.ToString("F2")}"),
                new ReportParameter("StudentID", stud.StudentID.ToString())
            };
            RVSchedulePayment.LocalReport.SetParameters(p);

            ReportDataSource ds = new ReportDataSource("DSSchedule", list);
            RVSchedulePayment.LocalReport.DataSources.Clear();
            RVSchedulePayment.LocalReport.DataSources.Add(ds);


            this.RVSchedulePayment.RefreshReport();

        }

        public bool IsSendEmail()
        {
            bool HasError = false;  
            try
            {
                string mymail = "eyyyyay7@gmail.com";
                string pass = GlobalConnection.ConnectionName;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(mymail, pass),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(mymail),
                    Subject = $"Your Bienvenido Online Tutoring Schedule Receipt from {DateTime.Now}",
                    Body = "Please find the attached receipt schedule.",
                    IsBodyHtml = true
                };

                foreach (var t in tutor)
                    mailMessage.To.Add(t.Email);

                mailMessage.To.Add(stud.ContactDetails);

                RVSchedulePayment.SetDisplayMode(DisplayMode.PrintLayout);
                RVSchedulePayment.ZoomMode = ZoomMode.PageWidth;
                RVSchedulePayment.ZoomPercent = 100;

                string deviceInfo = "<DeviceInfo><EmbedFonts>True</EmbedFonts></DeviceInfo>";

                Warning[] warnings;
                string[] streamIds;
                string mimeType, encoding, extension;


                byte[] pdfBytes = RVSchedulePayment.LocalReport.Render(
                    "PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

                string pdfPath = "ReceiptSchedule.Pdf";

                File.WriteAllBytes(pdfPath, pdfBytes);
                if (File.Exists(pdfPath))
                {
                    Attachment attachment = new Attachment(pdfPath);
                    mailMessage.Attachments.Add(attachment);
                }
                else
                {
                    MessageBox.Show("Error: PDf File not found. ");
                    HasError = true;
                }

                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully with pdf attachment!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
                HasError = true;
            }
            return HasError;
        }
    }
}
