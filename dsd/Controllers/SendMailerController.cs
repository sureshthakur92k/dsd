using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace dsd.Controllers
{
    public class SendMailerController : Controller
    {
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public string Index1(dsd.Models.MailModel _objModelMail)
        {
            bool msg = false;
            //return "";
           // if (ModelState.IsValid)
           // {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                // setup Smtp authentication
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("suresh.thakur92k@gmail.com", "suresh92k");
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                MailMessage msg1 = new MailMessage();
                msg1.From = new MailAddress(_objModelMail.From);
                msg1.To.Add(new MailAddress(_objModelMail.To));

                msg1.Subject = "This is a test Email subject";
                msg1.IsBodyHtml = true;
                msg1.Body = string.Format("<html><head></head><body><b>Test HTML Email</b></body>");
                try
                {
                    client.Send(msg1);
                    return "OK";
                }
                catch (Exception ex)
                {
                    return "error:" + ex.ToString();
                }
           // }         
        }
    }
}