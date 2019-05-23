using MvcMovie.Models;

namespace Queries.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithGenre(string genre);
    }
}
