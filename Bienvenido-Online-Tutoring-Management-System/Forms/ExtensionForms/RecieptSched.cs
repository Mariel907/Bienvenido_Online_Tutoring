﻿using Bienvenido_Online_Tutoring_Management_System.Model;
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
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{t.TutorName}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{t.Subject}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{t.SessionDate.ToString("MM/dd/yyyy")}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{t.StartTime}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{t.EndTime}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{$"₱{t.HourlyRate.ToString("F2")}"}</td>
                                      <td style='color: black; border: 1px  solid #c4cbe9;'>{$"₱{t.TotalAmount.ToString("F2")}"}</td>
                                  </tr>";
                }

                string StudentID = stud.StudentID.ToString();
                string StudentName = stud.StudentName.ToString();
                string Date = DateTime.Now.ToString("MM/dd/yyyy");

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(mymail),
                    Subject = $"Your Bienvenido Online Tutoring Scheduled Receipt from {DateTime.Now}",
                    Body = $@"
                          <!DOCTYPE html>

                          <HTML>
                          <head>
                              </head>
                              <body style='font-family: Arial;'>
                                    <div>
                                        <p style='font-size: 18px; font-weight: bold; text-align: left;'>Scheduled Receipt Payment</p>
                                        <p style='font-size: 14px; text-align: left;'>Beinvenido Online Tutoring Management System</p>
                                </div>
                               <hr>
                                  <div style='margin-top: 15px; font-size: 14px;'>
                                     <p><strong>Student ID:</strong>
                                            <span style='display: inline-block; text-align: right; max-width: 150px'>{StudentID}</span></p>
                                     <p><strong>Student Name:</strong> 
                                            <span style='display: inline-block; text-align: right; max-width: 100px'>{StudentName}</span></p>
                                     <p><strong>Date:</strong>
                                            <span style='display: inline-block; text-align: right; max-width: 150px'>{Date}</span></p>
                                  </div>
                              <hr>
                              <table style='width:100%; 
                                            text-align: left; 
                                            color: #fff;
                                            border: 1px  solid #c4cbe9;
                                            border-collapse: collapse;
                        font-size:14px;'>
                                  <tr>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                              '>Tutor Name</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                               '>Subject</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                              '>Session Date</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                               '>Start Time</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                               '>End Time</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                              '>Hrly Rate</th>
                                      <th style='border: 1px  solid #c4cbe9; background-color: #06172e;
                                                '>Total</th>
                                  </tr>
                                    {tutorRows}
                              </table>
                                <hr>

                                  <div style='margin-top: 15px;
                                  font-size:14px;'>
                                    <table style='width: 100%; border-collapse: collapse;'>
                                    <tr>
                                        <td><strong>Enrollment Fee:</strong></td>
                                        <td style='text-align: right;'>{Fee}</td>
                                    </tr>
                                    <tr>
                                        <td><strong>Cash:</strong></td>
                                        <td style='text-align: right;'>{cash}</td>
                                    </tr>
                                    <tr>
                                         <td><strong>Changed:</strong></td>
                                         <td style='text-align: right;'>{Changed}</td>
                                    </tr>
                                    </table>
                                  </div>
                              <hr>
      
                            <p style='font-size: 14px;'>Thank you for trusting our online tutoring service to support your academic journey. Your dedication to learning and excellence inspires us. We are honored to be part of your success, and we look forward to continuing to help you achieve your educational goals!</p>
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
