using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Controllers
{
	[Route("api/v1/MovieApiController")]
    public class MovieApiController : MovieAppController
    {

		private readonly IUnitOfWork _unitOfWork;

        public MovieApiController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
			this._unitOfWork = unitOfWork;
        }

        [HttpPost("Comment")]
		[ValidateAntiForgeryToken]
		public string Comment(CommentViewModel commentVM)
		{
			Comment comment = new Comment(commentVM);
		    UnitOfWork.Comments.Update(comment);
		    UnitOfWork.Complete();
            return ("Ok");
		}
    }
}
