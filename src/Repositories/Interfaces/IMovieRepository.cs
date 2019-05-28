using System.Collections.Generic;
using MvcMovie.Models;

namespace Queries.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMovieWithGenre(string genre);
        IEnumerable<Movie> GetMovieWithPartTitle(string searchString);
        IEnumerable<Movie> GetMoviesIntersection(IEnumerable<Movie> movie1, IEnumerable<Movie> movie2);
    }
}
