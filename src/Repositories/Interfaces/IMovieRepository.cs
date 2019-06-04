using MvcMovie.Models;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithGenre(string genre);
    }
}
