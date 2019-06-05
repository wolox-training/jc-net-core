using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using src.Models;
using System.Diagnostics;

namespace MvcMovie.Controllers
{

    [Authorize]
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
            Movie movie = new Movie();
            MovieViewModel movieVM = new MovieViewModel(movie);
            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Movies.Add(movie);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            MovieViewModel movieVM = new MovieViewModel(movie);
            return View(movieVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            MovieViewModel mvm = new MovieViewModel(movie);

            if (movie == null)
            {
                return NotFound();
            }
            return View(mvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Movies.Update(movie);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, bool notUsed)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                UnitOfWork.Movies.Remove(movie);
                UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int id)
        {
            return View(UnitOfWork.Movies.Get(id));
        }
    }
}
