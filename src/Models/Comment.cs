using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public Comment() { }
        public Comment(CommentViewModel commentVM)
        {
			this.Title = commentVM.Title;
			this.Content = commentVM.Content;
			this.CreatedAt = DateTime.Now;
			this.MovieId = commentVM.MovieId;
        }
    }
}
