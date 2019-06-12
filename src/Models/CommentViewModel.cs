using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(){ }
        public CommentViewModel(IEnumerable<Comment> comments, Movie movie)
        {
            this.Comments = comments;
            this.movie = movie;
        }
        public Movie movie {get; set; }

        public IEnumerable<Comment> Comments {get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
