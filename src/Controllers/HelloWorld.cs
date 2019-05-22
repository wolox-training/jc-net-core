using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Queries.Core;

namespace src.Controllers
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
