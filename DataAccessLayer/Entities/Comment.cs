using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Class for comment model
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Comment identificator
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// Comment author
        /// </summary>
        [Required(ErrorMessage = "Author was not input")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Incorrect nickname length")]
        [RegularExpression(@"^[A-Z]{1}\w+", ErrorMessage = "Incorrect symbols in nickname input")]
        public string Author { get; set; }
        /// <summary>
        /// Comment publication date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Comment description
        /// </summary>
        [Required(ErrorMessage = "Description was not input")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Your comment is too long")]
        public string Description { get; set; }
    }
}