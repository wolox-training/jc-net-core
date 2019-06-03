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
        public IActionResult Index(string movieGenre, string searchString, string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Title" : "";
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Price" : "";
            ViewData["GenreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Genre" : "";
            ViewData["RatingSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Rating" : "";

            var movies = UnitOfWork.Movies.GetAll();

            switch (sortOrder)
            {
                case "Title":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseDate).ThenBy(m => m.Title);
                    break;
                case "Price":
                    movies = movies.OrderBy(m => m.Price).ThenBy(m => m.Title);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.Genre).ThenBy(m => m.Title);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating).ThenBy(m => m.Title);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }

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
        public IActionResult Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
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
