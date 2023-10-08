using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using Utility;
using System.Web.UI.WebControls;

namespace Component
{
    public class Mail
    {
        ManageException ObjExp = new ManageException();

        public Mail()
        {
        }
        private string _mailTo = string.Empty;
        private string _mailCc = string.Empty;
        private string _mailBCc = string.Empty;
        private string _subject = string.Empty;
        private string _body = string.Empty;
        private string _mailAddress = string.Empty;
        private string _title = string.Empty;

        public string MailTo
        {
            get { return _mailTo; }
            set { _mailTo = value; }
        }
        public string MailCc
        {
            get { return _mailCc; }
            set { _mailCc = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public string MailAddress
        {
            get { return _mailAddress; }
            set { _mailAddress = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string MailBCc
        {
            get { return _mailBCc; }
            set { _mailBCc = value; }
        }

        public void SendMail()
        {
            //string smtpServer = "smtp.gmail.com";
            //string userName = "noreplyauthentication347@gmail.com";
            //string password = "ujbprbbcjsqrujph";
            string smtpServer = "smtp.gmail.com";
            string userName = "noreply@aapnoghar.com";
            string password = "Aapno#@1234";
            if (MailTo == "")
            {
                MailTo = "info@aapnoghar.com";
            }
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                if (userName.Length > 0)
                {
                    smtpClient.Host = smtpServer;
                    smtpClient.Port = 587;
                    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(userName, password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = SMTPUserInfo;

                }
                if (MailTo == "test@ibrandox.com")
                {
                    msg.To.Add("azeem.ibrandox@gmail.com");
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                }
                else
                {
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                    msg.To.Add(MailTo);
                }
                MailAddress ma = new MailAddress("noreply@aapnoghar.com", Title);
                msg.From = ma;
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                msg.Body = Body;
                smtpClient.Host = smtpServer;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                ObjExp.PublishError("Error in procedure SendMail()", ex);
            }
            finally
            {
                msg.Dispose();
                smtpClient.Dispose();
            }
        }

        public void SendMailForOTP()
        {
            string smtpServer = "smtp.gmail.com";
            string userName = "noreply@aapnoghar.com";
            string password = "Aapno#@1234";
            if (MailTo == "")
            {
                MailTo = "info@aapnoghar.com";
            }
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                if (userName.Length > 0)
                {
                    smtpClient.Host = smtpServer;
                    smtpClient.Port = 587;
                    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(userName, password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = SMTPUserInfo;

                }
                if (MailTo == "test@ibrandox.com")
                {
                    msg.To.Add("azeem.ibrandox@gmail.com");
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                }
                else
                {
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                    msg.To.Add(MailTo);
                }
                MailAddress ma = new MailAddress("noreply@aapnoghar.com", Title);
                msg.From = ma;
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                msg.Body = Body;
                smtpClient.Host = smtpServer;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                ObjExp.PublishError("Error in procedure SendMail()", ex);
            }
            finally
            {
                msg.Dispose();
                smtpClient.Dispose();
            }
        }

        public void SendMail303(System.Web.UI.HtmlControls.HtmlInputFile UploadedCV)
        {
            string smtpServer = "smtp.gmail.com";
            string userName = "noreply@aapnoghar.com";
            string password = "Aapno#@1234";
            if (MailTo == "")
            {
                MailTo = "info@aapnoghar.com";
            }
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                if (userName.Length > 0)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                    smtpClient.Host = smtpServer;
                    smtpClient.Port = 587;
                    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(userName, password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = SMTPUserInfo;

                }
                if (MailTo == "test@ibrandox.com")
                {
                    msg.To.Add("azeem.ibrandox@gmail.com");
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                }
                else
                {
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                    msg.To.Add(MailTo);
                }
                MailAddress ma = new MailAddress("noreply@aapnoghar.com", Title);
                msg.From = ma;
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                msg.Body = Body;
                smtpClient.Host = smtpServer;
                if (UploadedCV.Value != "")
                {
                    msg.Attachments.Add(new Attachment(UploadedCV.PostedFile.InputStream, UploadedCV.PostedFile.FileName));
                }
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                ObjExp.PublishError("Error in procedure SendMail()", ex);
            }
            finally
            {
                msg.Dispose();
                smtpClient.Dispose();
            }
        }

        public void SendMailInvoice(string CustInvoice)
        {
            //string smtpServer = "smtp.gmail.com";
            //string userName = "noreplyauthentication347@gmail.com";
            //string password = "ujbprbbcjsqrujph";
            string smtpServer = "smtp.gmail.com";
            string userName = "noreply@aapnoghar.com";
            string password = "Aapno#@1234";
            if (MailTo == "")
            {
                MailTo = "info@aapnoghar.com";
            }
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                if (userName.Length > 0)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                    smtpClient.Host = smtpServer;
                    smtpClient.Port = 587;
                    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(userName, password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = SMTPUserInfo;
                }
                if (MailTo == "test@ibrandox.com")
                {
                    msg.To.Add("azeem.ibrandox@gmail.com");
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                }
                else
                {
                    if (MailCc != "")
                        msg.CC.Add(MailCc);
                    msg.To.Add(MailTo);
                }
                MailAddress ma = new MailAddress("noreply@aapnoghar.com", Title);
                msg.From = ma;
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                msg.Body = Body;
                smtpClient.Host = smtpServer;
                if (CustInvoice != "")
                {
                    msg.Attachments.Add(new Attachment(CustInvoice));
                }
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                ObjExp.PublishError("Error in procedure SendMail()", ex);
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
