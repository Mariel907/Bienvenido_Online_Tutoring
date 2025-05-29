using Bienvenido_Online_Tutoring_Management_System.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
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

            SendEmail();

            this.RVSchedulePayment.RefreshReport();

        }

        public void SendEmail()
        {
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

                string cash = $"₱{stud.Cash.ToString("F2")}";
                string Changed = $"₱{stud.Changed.ToString("F2")}";
                string Fee = $"₱{stud.EnrollmentFee.ToString("F2")}";

                string tutorRows = "";

                foreach (var t in list)
                {
                    tutorRows += $@"
          <tr>
              <td>{t.TutorName}</td>
              <td>{t.Subject}</td>
              <td>{t.SessionDate.ToString("MM/dd/yyyy")}</td>
              <td>{t.StartTime}</td>
              <td>{t.EndTime}</td>
              <td>{$"₱{t.HourlyRate.ToString("F2")}"}</td>
              <td>{$"₱{t.TotalAmount.ToString("F2")}"}</td>
          </tr>";
                }

                string Style = @"  
      <style>
body { font-family: Segoe UI; }
          .header-text {margin-left: 20px;}
          .title { font-size: 24px;font-weight: bold; }
          .subtitle{ font-size: 18px; color; #555; }
          table, th, td {
text-align: left;
color: #fff;
border: 1px  solid black;
border-collapse: collapse;
}
         th {
background-color: #06172e;
}
td {
color: #000000;
}
          .student-info { margin-top: 15px;
          font-size:16px;
              
              }
              .payment-info p {
               display: flex;
              justify-content: space-between;
              margin-top: 15px;
              font-size: 16px;
             width: 100px;
              }
              .payment-info .amount {
              text-align: right;
             flex-grow: 1;
             max-width: 150px;
              }
      </style>
";

                string compute = $@"";
                string StudentID = stud.StudentID.ToString();
                string StudentName = stud.StudentName.ToString();
                string Date = DateTime.Now.ToString("MM/dd/yyyy");

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(mymail),
                    Subject = $"Your Bienvenido Online Tutoring Schedule Receipt from {DateTime.Now}",
                    Body = $@"
                 <!DOCTYPE html>
  <HTML>
  <head>
        {Style}
      </head>
      <body>
            <div class='header-text'>
                <p class='title'>Scheduled Receipt Payment</p>
                <p class='subtitle'>Beinvenido Online Tutoring Management System</p>
        </div>
       <hr>
          <div class='student-info'>
             <p><strong>Student ID:</strong> {StudentID} </p>
             <p><strong>Student Name:</strong> {StudentName} </p>
             <p><strong>Date:</strong> {Date} </p>
          </div>
      <hr>
      <table style='width:100%'>
          <tr>
              <th>Tutor Name</th>
              <th>Subject</th>
              <th>Date</th>
              <th>Start Time</th>
              <th>End Time</th>
              <th>Hrly Rate</th>
              <th>Total</th>
          </tr>
            {tutorRows}
      </table>
        <hr>
          <div class='payment-info'>
             <p><strong>Enrollment Fee:</strong> <span class='amount'>{Fee} </span></p>
             <p><strong>Cash:</strong> <span class='amount'>{cash}</span> </p>
             <p><strong>Changed:</strong> <span class='amount'>{Changed}</span></p>
          </div>
      <hr>
      
    <p>Thank you for trusting our online tutoring service to support your academic journey. Your dedication to learning and excellence inspires us. We are honored to be part of your success, and we look forward to continuing to help you achieve your educational goals!</p>
  </body>
  </html>

",
                    IsBodyHtml = true
                };

                foreach (var t in tutor)
                    mailMessage.To.Add(t.Email);

                mailMessage.To.Add(stud.ContactDetails);

                RVSchedulePayment.SetDisplayMode(DisplayMode.PrintLayout);
                RVSchedulePayment.ZoomMode = ZoomMode.PageWidth;
                RVSchedulePayment.ZoomPercent = 100;


                //Warning[] warnings;
                //string[] streamIds;
                //string mimeType, encoding, extension;
                //string deviceInfo = "<DeviceInfo><EmbedFonts>True</EmbedFonts></DeviceInfo>";

                //byte[] pdfBytes = RVSchedulePayment.LocalReport.Render(
                //    "PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

                //string pdfPath = "ReceiptSchedule.Pdf";

                //File.WriteAllBytes(pdfPath, pdfBytes);
                //if (File.Exists(pdfPath))
                //{
                //    Attachment attachment = new Attachment(pdfPath);
                //    mailMessage.Attachments.Add(attachment);
                //}
                //else
                //{
                //    MessageBox.Show("Error: PDf File not found. ");
                //}

                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("The email address does not exist, so we are unable to send the scheduled receipt to your Gmail. Please verify the recipient's email and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
