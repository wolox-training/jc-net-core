using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovie.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using Mailer;
using MvcMovie.Models;

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


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string Name, string Adress, string Subject, string Body)
        {
            EmailMessage mailMessage= new EmailMessage();
            EmailAddress to = new EmailAddress();
            to.Name = Name;
            to.Address = Adress;
            mailMessage.ToAddresses.Add(to);
            EmailAddress fromI = new EmailAddress();
            fromI.Name = "YoFalso";
            fromI.Address = "pruebafalso4@gmail.com";
            mailMessage.FromAddresses.Add(fromI);
            mailMessage.Subject= Subject;
            mailMessage.Content= Body;
            _Mailer.Send(mailMessage);

            return RedirectToAction("Index");

        }
    }
}
