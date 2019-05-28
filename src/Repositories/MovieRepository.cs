using Queries.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;
using System.Collections.Generic;

namespace Queries.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MvcMovieContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetMovieWithGenre(string genre)
        {
            return MvcMovieContext.Movies.Where(g => g.Genre == genre);
        }

        public MvcMovieContext MvcMovieContext
        {
            get { return Context as MvcMovieContext; }
        }

        public IEnumerable<Movie> GetMovieWithPartTitle(string searchString)
        {
            return MvcMovieContext.Movies.Where(m => m.Title.Contains(searchString));
        }

        public IEnumerable<Movie> GetMoviesIntersection(IEnumerable<Movie> movie1, IEnumerable<Movie> movie2)
        {
            return movie1.Intersect(movie2);
        }
    }
}