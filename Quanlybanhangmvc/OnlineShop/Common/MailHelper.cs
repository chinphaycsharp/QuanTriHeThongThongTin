using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Common
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

                bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

                string body = content;
                MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                var client = new SmtpClient();
                client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                client.Host = smtpHost;
                client.EnableSsl = enabledSsl;
                client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                client.UseDefaultCredentials = true;
                client.Send(message);
                //string Username = WebConfigurationManager.AppSettings["PFUserName"].ToString();
                //string Password = WebConfigurationManager.AppSettings["PFPassWord"].ToString();
                //string MailServer = WebConfigurationManager.AppSettings["MailServerName"].ToString();
                //string Host = WebConfigurationManager.AppSettings["SMTPPort"].ToString();
                //NetworkCredential cred = new NetworkCredential(Username, Password);
                //string mailServerName = ("smtp.gmail.com,587");



                //MailMessage message = new MailMessage(toEmailAddress,Username, subject, content);
                //SmtpClient mailClient = new SmtpClient(Host);
                //mailClient.EnableSsl = true;

                //mailClient.Host = Host;
                //mailClient.UseDefaultCredentials = false;
                //mailClient.Credentials = cred;
                //mailClient.Send(message);
                //message.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
