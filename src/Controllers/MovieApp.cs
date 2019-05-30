using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;

namespace MovieApp.Controllers
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
            return View(UnitOfWork.Movies.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            UnitOfWork.Movies.Add(movie);
            UnitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
