using MvcMovie.Repositories;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Models;

namespace MvcMovie.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcMovieContext _context;

        public UnitOfWork(MvcMovieContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Comments = new CommentRepository(_context);
        }

        public IMovieRepository Movies { get; private set; }

        public ICommentRepository Comments { get; private set; }

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
