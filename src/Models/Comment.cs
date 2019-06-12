using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
