using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using src.Models;
using System.Diagnostics;

namespace MovieApp.Controllers
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
        public IActionResult Index(string movieGenre, string searchString)
        {
            var movies = UnitOfWork.Movies.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var genresquery = movies.Select(m => m.Genre).ToArray();
            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(genresquery.Distinct().ToList()),
                Movies = movies.ToList()
            };

            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,ReleaseDate,Genre,Price, Rating")]Movie movie)
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
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
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
