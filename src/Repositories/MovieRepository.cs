using Queries.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;
using MvcMovie.Repositories.DataBase;

namespace Queries.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MvcMovieContext context) : base(context)
        {
        }

        public Movie GetMovieWithId(int id)
        {
            return MvcMovieContext.Movies.Include(m => m.Id).SingleOrDefault(m => m.Id == id);
        }

        public MvcMovieContext MvcMovieContext
        {
            get { return Context as MvcMovieContext; }
        }
    }
}