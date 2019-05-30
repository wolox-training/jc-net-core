using System.Collections.Generic;
using MvcMovie.Models;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMovieWithGenre(string genre);
        IEnumerable<Movie> GetMovieWithPartTitle(string searchString);
    }
}
