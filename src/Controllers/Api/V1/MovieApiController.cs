using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    public class MovieApiController : MovieAppController
    {
        public MovieApiController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Comment(int id, Comment comment)
		{
		    if (ModelState.IsValid)
		    {
		        comment.ReleaseDate = DateTime.Now;
                comment.MovieID = id;
		        UnitOfWork.Comments.Update(comment);
		        UnitOfWork.Complete();
                var a = Json(comment);
                return Json(comment);
		    }
		    return Json("Error");
		}
    }
}