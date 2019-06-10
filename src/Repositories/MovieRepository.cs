using MvcMovie.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;
using System.Collections.Generic;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MvcMovieContext context) : base(context)
        {
        }

        public MvcMovieContext MvcMovieContext
        {
            get { return Context as MvcMovieContext; }
        }
    }
}
