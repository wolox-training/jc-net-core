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
            this.CreatedAt = c.CreatedAt;
            this.MovieId = c.MovieId;
        }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public int MovieId { get; set; }
    }
}
