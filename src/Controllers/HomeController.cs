using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovie.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = _localizer["HomePage"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IHtmlLocalizer<HomeController> _localizer;

        public HomeController(IHtmlLocalizer<HomeController> localizer) => this._localizer = localizer;

        [Authorize]
        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost,ActionName("Contact")]
        public IActionResult ContactSend()
        {
            SmtpClient client = new SmtpClient("smtp.mailtrap.io");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("6005220a480d62", "6531177fbc4017");
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("559eeb2ac5-e0bff9@inbox.mailtrap.io");
            mailMessage.To.Add("marcos.trucco@wolox.com.ar");
            mailMessage.Body = "Don't Worry, be Happy";
            mailMessage.Subject = "Mail Test";
            client.Send(mailMessage);
            return View();
        }
    }
}
