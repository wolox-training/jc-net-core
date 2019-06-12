using Mailer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Route("api/v1/HomeApiController")]
    public class HomeApiController : HomeController
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;
        public HomeApiController(IHtmlLocalizer<HomeController> localizer, IEmailService mailer) : base(localizer, mailer)
        {
            this._localizer = localizer;
        }

        [HttpPost("Contact")]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(EmailViewModel email)
        {
            EmailAddress to = new EmailAddress(){
                Name = email.Name,
                Address = email.Adress
            };
            EmailMessage mailMessage= new EmailMessage(){
                Subject = email.Subject,
                Content = email.Body,
            };
            mailMessage.ToAddresses.Add(to);
            Mailer.Send(mailMessage);
            return Ok("Ok");
        }
    }
}
