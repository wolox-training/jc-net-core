using Microsoft.AspNetCore.Mvc;
using Queries.Core;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Movie movie)
        {
            UnitOfWork.Movies.Add(movie);
            UnitOfWork.Complete();
            return RedirectPermanent("/MovieApp");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            } 
            else if (ModelState.IsValid)
            {
                UnitOfWork.Movies.Update(movie);
                UnitOfWork.Complete();
            }
            return RedirectPermanent("/MovieApp");
        }
    }
}
