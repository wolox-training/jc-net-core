using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovie.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using Mailer;

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

        public HomeController(IHtmlLocalizer<HomeController> localizer,IEmailService Mailer)
        {
            this._localizer = localizer;
            _Mailer = Mailer;
        } 

        [Authorize]
        public IActionResult Privacy() => View();

        private readonly IEmailService _Mailer;

        public IActionResult Contact()
        {
            EmailMessage mailMessage= new EmailMessage();
            EmailAddress to = new EmailAddress();
            to.Name = "Falso";
            to.Address = "jose.casanova@wolox.com.ar";
            mailMessage.ToAddresses.Add(to);
            EmailAddress fromI = new EmailAddress();
            fromI.Name = "YoFalso";
            fromI.Address = "pruebafalso4@gmail.com";
            mailMessage.FromAddresses.Add(fromI);
            mailMessage.Subject="Mail Test";
            mailMessage.Content="Don't Worry, be Happy";
            _Mailer.Send(mailMessage);

            return View();

        }
    }
}
