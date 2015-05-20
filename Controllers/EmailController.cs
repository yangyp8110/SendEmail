using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using SendEmail.Helper;
using System.Configuration;

namespace SendEmail.Controllers
{
    public class EmailController : Controller
    {
        private readonly string ReciversPath = AppDomain.CurrentDomain.BaseDirectory + "Files\\Receiver.txt";
        private readonly string ContentBodyPath = AppDomain.CurrentDomain.BaseDirectory + "Files\\EmailTemplate.html";
        private readonly string Subject = ConfigurationManager.AppSettings["Subject"];
        
        public ActionResult Send()
        {
            string toEmail = Utils.ReadByLine(ReciversPath, '|');
            string emailBody = Utils.ReadFile(ContentBodyPath);
            string subject = Subject;

            try
            {
                if (toEmail.IndexOf("|") > 0)
                {
                    var recivers = toEmail.Split('|').ToList();
                    recivers.ForEach(p => JMail.SendEmail(subject, emailBody, p));
                }
                else
                {
                    JMail.SendEmail(subject, emailBody, toEmail);
                }
                return Json(new { status = 0, msg = "发送成功！" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = -1001, msg = "发送失败！" }, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}
