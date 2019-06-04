using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HelloWorldController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    
        public IUnitOfWork UnitOfWork
        {
            get { return this._unitOfWork; }
        }
        public IActionResult Index()
        {
            return View();
        } 
    }
}
