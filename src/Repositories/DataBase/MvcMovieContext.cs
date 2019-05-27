using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : IdentityDbContext<IdentityUser>
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options): base(options){}

        public DbSet<Movie> Movies { get; set; }
    }
}
