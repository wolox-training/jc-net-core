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
using System;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = _localizer["HomePage"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IHtmlLocalizer<HomeController> _localizer;
        private readonly IEmailService _mailer;
        public IHtmlLocalizer<HomeController> Localizer => this._localizer;
        public IEmailService Mailer => this._mailer;

        public HomeController(IHtmlLocalizer<HomeController> localizer,IEmailService mailer)
        {
            this._localizer = localizer;
            _mailer = mailer;
        } 

        [Authorize]
        [HttpGet]
        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
