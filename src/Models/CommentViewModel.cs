using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(){ }
        public CommentViewModel(Comment c)
        {
            this.Title = c.Title;
            this.Content = c.Content;
            this.ReleaseDate = c.ReleaseDate;
            this.MovieId = c.MovieID;
        }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int MovieId { get; set; }
    }
}
