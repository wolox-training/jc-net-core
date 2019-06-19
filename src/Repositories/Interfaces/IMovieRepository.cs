using System.Collections.Generic;
using MvcMovie.Models;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie Get (int id);
    }
}
