using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Queries.Core;

namespace src.Controllers
{
    public class MovieAppController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieAppController(IUnitOfWork unitOfWork)
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

        public IActionResult Create()
        {
            return View();
        } 
    }
}
