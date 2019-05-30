using MvcMovie.Repositories.Interfaces;
using System;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        int Complete();
    }
}
