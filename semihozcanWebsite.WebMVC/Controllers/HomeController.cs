using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using semihozcanWebsite.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace semihozcanWebsite.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;

        public HomeController(ILogger<HomeController> logger, EmailAddress fromAndToEmailAddress, IEmailService emailService)
        {
            _logger = logger;
            FromAndToEmailAddress = fromAndToEmailAddress;
            EmailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Here is your message: Name: {model.SenderName}, " +
                        $"Email: {model.SenderEmail}, Message: {model.Message}",
                    Subject = "Contact Form - BasicContactForm App"
                };

                EmailService.Send(msgToSend);
                ViewBag.Message = "Email Successfully Sent";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Email Failed to Send";
                return View(model);
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
