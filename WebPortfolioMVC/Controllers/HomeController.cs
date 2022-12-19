using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPortfolioMVC.Models;

namespace WebPortfolioMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return PartialView("_Contact");
        }

        [HttpPost]
        public JsonResult Message(MessageModel message)
        {
            if (!ModelState.IsValid) return Json("Invalid Entry");

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(message.Email);
                    mail.To.Add("Nathan.Bosman.Software@gmail.com");
                    mail.Subject = $"{message.Name} sent a message from your Web Porfolio!";
                    mail.Body = $@"
                    <h2>{message.Subject}</h2>
                    <p> {message.Message} </p>
                    <p> reply: {message.Email}</p>
                     ";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("Nathan.Bosman.Software@gmail.com", "qszdadoxiafdyvjp");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return Json("Message Sent!");
            }

            catch(Exception ex)
            {
                return Json("Error: " + ex);
            }
        }

        public IActionResult Home()
        {
            return PartialView("_Index");
        }

        public IActionResult Projects()
        {
            return PartialView("_Projects");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
