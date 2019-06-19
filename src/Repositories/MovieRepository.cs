using MvcMovie.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MvcMovieContext context) : base(context) { }

        public MvcMovieContext MvcMovieContext
        {
            get { return Context as MvcMovieContext; }
        }

        public void IncludeComments()
        {
            Context.Set<Movie>().Include(m => m.Comments).ToList();;
        }

        public override Movie Get (int id)
        {
            Movie m = Context.Set<Movie>().Find(id);
            IncludeComments();
            return m;
        }
    }
}
