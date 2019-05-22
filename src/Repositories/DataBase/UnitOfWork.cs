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
            Courses = new MovieRepository(_context);
        }

        public IMovieRepository Courses { get; private set; }

        public IMovieRepository Movies => throw new System.NotImplementedException();

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
