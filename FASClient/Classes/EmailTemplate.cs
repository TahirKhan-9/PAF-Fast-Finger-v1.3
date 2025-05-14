using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class EmailTemplate
    {
        
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        public bool Save()
        {
            string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);
            try
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, "delete from emailtemplate");
                this.ID = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
                if (this.ID >= 1)
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }
        public void Email(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("tech@ddspak.com");
                message.To.Add(new MailAddress("zaheer@ddspak.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 465;
                smtp.Host = "ddspak.com"; //for gmail host  
                
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tech@ddspak.com", "Masood@Hateem@2019");
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //Disable_CertificateValidation();
                smtp.Send(message);
            }
            catch (Exception ex) { }
        }

        //[Obsolete("Do not use this in Production code!!!", true)]
        static void Disable_CertificateValidation()
        {
            // Disabling certificate validation can expose you to a man-in-the-middle attack
            // which may allow your encrypted message to be read by an attacker
            // https://stackoverflow.com/a/14907718/740639
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                ) {
                    return true;
                };
        }
        public bool Delete()
        {
            try
            {
                DBFactory.Delete(Globals.GetConnectionString(), this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                return DBFactory.GetAll(Globals.GetConnectionString(), "EmailTemplate");
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public EmailTemplate() { }

        public EmailTemplate(string _subject, string _header, string _body, string _footer)
        {
            this.Subject = _subject;
            this.Header = _header;
            this.Body = _body;
            this.Footer = _footer;
        }

        public EmailTemplate Get()
        {
            EmailTemplate template = new EmailTemplate();
            DataTable dt = GetAll();
            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                template = Globals.GetItem<EmailTemplate>(row);
            }


            return template;
        }
    }
}
