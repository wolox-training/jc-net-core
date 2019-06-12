using System;
using System.Linq;
using Mailer;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Controllers
{
	[Route("api/v1/MovieApiController")]
    public class MovieApiController : MovieAppController
    {

		private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _mailer;
        
        public MovieApiController(IUnitOfWork unitOfWork, IEmailService mailer) : base(unitOfWork, mailer)
        {
        }

        [HttpPost("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult Details(EmailViewModel email)
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
            return Ok("Success");
        }
    }
}
