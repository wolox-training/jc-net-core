using System.Collections.Generic;
using MvcMovie.Models;

namespace Queries.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMovieWithGenre(string genre);
        IEnumerable<Movie> GetMovieWithPartTitle(string genre);
    }
}
