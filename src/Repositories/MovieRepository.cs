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
    }
}
