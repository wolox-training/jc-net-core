using MvcMovie.Models;

namespace Queries.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithId(int id);
    }
}