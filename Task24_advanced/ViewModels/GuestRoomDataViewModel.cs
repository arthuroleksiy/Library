using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task24_advanced.ViewModels
{
    public class GuestRoomDataViewModel
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Please enter your nickname")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Incorrect nickname length")]
        [RegularExpression(@"^[A-Z]{1}\w+", ErrorMessage = "Incorrect symbols in nickname input")]
        public string Author { get; set; }
        public string Date { get; set; }
        [Required(ErrorMessage = "Please enter comment text")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Your comment is too long")]
        public string Description { get; set; }
    }
}