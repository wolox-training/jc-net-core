using Queries.Core;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;
using MvcMovie.Models;

namespace Queries.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcMovieContext _context;

        public UnitOfWork(MvcMovieContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
        }

        public IMovieRepository Movies { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
