using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using src.Models;
using System.Diagnostics;
using Mailer;

namespace MvcMovie.Controllers
{

    [Authorize]
    public class MovieAppController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _mailer;
        private IUnitOfWork unitOfWork;

        public IEmailService Mailer => this._mailer;

        public MovieAppController(IUnitOfWork unitOfWork, IEmailService mailer)
        {
            this._unitOfWork = unitOfWork;
            _mailer = mailer;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return this._unitOfWork; }
        }

        [HttpGet]
        public IActionResult Index(string movieGenre, string searchString, string sortOrder, int? pageNumber)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Title" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["GenreSortParm"] = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewData["RatingSortParm"] = sortOrder == "Rating" ? "rating_desc" : "Rating";
            var movies = UnitOfWork.Movies.GetAll();
            var genresquery = movies.Select(m => m.Genre).ToArray();
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["GenreFilter"] = movieGenre;
            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(s => s.Title.Contains(searchString));
            if (!string.IsNullOrEmpty(movieGenre))
                movies = movies.Where(x => x.Genre == movieGenre);
            switch (sortOrder)
            {
                case "Title":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseDate).ThenBy(m => m.Title);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseDate).ThenBy(m => m.Title);
                    break;
                case "Price":
                    movies = movies.OrderBy(m => m.Price).ThenBy(m => m.Title);
                    break;
                case "price_desc":
                    movies = movies.OrderByDescending(m => m.Price).ThenBy(m => m.Title);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.Genre).ThenBy(m => m.Title);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(m => m.Genre).ThenBy(m => m.Title);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating).ThenBy(m => m.Title);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating).ThenBy(m => m.Title);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }
            int  pageSize = 3;
            var Genres = new SelectList(genresquery.Distinct().ToList());
            var moviePage = PaginatedList<Movie>.Create(movies.ToList(),pageNumber ?? 1,pageSize,Genres);
            moviePage.Movies = movies.ToList();
            return View(moviePage);
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
        public IActionResult DeleteConfirmed(int id)
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

        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie movie = UnitOfWork.Movies.Get(id);
            MovieViewModel MovieVM = new MovieViewModel(movie);
            return View(MovieVM);
        }
    }
}
