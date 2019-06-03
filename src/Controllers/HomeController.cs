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

        public IActionResult Contact()
        {
            /* MAIL GENÉRICO
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pruebafalso4@gmail.com", "geougcahvdtcvwwu");
            client.Port=587;
            client.EnableSsl=true;
            
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("pruebafalso4@gmail.com");
            mailMessage.To.Add("jose.casanova@wolox.com.ar");
            mailMessage.IsBodyHtml=true;
            mailMessage.Body = "Don't Worry, be Happy";
            mailMessage.Subject = "Mail Test";
            client.Send(mailMessage);
            */
            return View();

        }
    }
}
