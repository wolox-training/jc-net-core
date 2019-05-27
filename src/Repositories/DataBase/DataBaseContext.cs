// src/Repositories/Database/DataBaseContext.cs

#region Using
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
#endregion

namespace MvcMovie.Repositories.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}