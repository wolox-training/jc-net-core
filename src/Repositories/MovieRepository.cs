using MvcMovie.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MvcMovieContext context) : base(context) { }

        public override Movie Get (int id)
        {
            return Context.Movies.Include(m => m.Comments).First(m => m.Id == id);
        }
    }
}
