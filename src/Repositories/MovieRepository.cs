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

        public Movie GetMovieWithGenre(string genre)
        {
            return MvcMovieContext.Movies.Include(g => g.Genre).SingleOrDefault(g => g.Genre == genre);
        }

        public MvcMovieContext MvcMovieContext
        {
            get { return Context as MvcMovieContext; }
        }
    }
}