using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string movieGenre { get; set; }
        public string searchString { get; set; }
    }
}
