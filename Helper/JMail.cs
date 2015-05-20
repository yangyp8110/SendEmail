using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SendEmail.Helper
{
    public class JMail
    {
        private static readonly string mailServerFromEmail = ConfigurationManager.AppSettings["MailServerFromEmail"];
        private static readonly string mailServerUserName = ConfigurationManager.AppSettings["MailServerUserName"];
        private static readonly string mailServerPassWord = ConfigurationManager.AppSettings["MailServerPassWord"];
        private static readonly string mailServer = ConfigurationManager.AppSettings["MailServer"];

        public static void SendEmail(string subject, string body, string toEmail)
        {
            body = body.Replace("<!--datetime-->", DateTime.Now.ToLongDateString());

            jmail.Message jmail = new jmail.Message();

            string fromEmail = mailServerFromEmail;
            string fromName = "天戏网络";
            //jmail.Silent = true;
            //jmail.Logging = true;
            jmail.Charset = "GB2312";
            jmail.ContentType = "text/html";
            jmail.From = fromEmail;
            jmail.FromName = fromName;
            /* 批量发邮件，收件者相互可见邮箱*/
            //if (toEmail.IndexOf("|") > 0)
            //{
            //    var recivers = toEmail.Split('|').ToList();
            //    recivers.ForEach(p => jmail.AddRecipient(p, "", ""));
            //}
            /* 一对一发邮件，收件者相互可见邮箱*/
            jmail.AddRecipient(toEmail, "", "");

            //jmail.MailServerUserName = mailServerUserName.Substring(0,mailServerUserName.IndexOf("@"));
            jmail.MailServerUserName = mailServerUserName;
            jmail.MailServerPassWord = mailServerPassWord;
            jmail.Subject = subject;
            jmail.Body = body;

            jmail.Send(mailServer, false);
            jmail.Close();
        }
    }
}