using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;

namespace MvcMovie.Controllers
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid){
                UnitOfWork.Movies.Add(movie);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
