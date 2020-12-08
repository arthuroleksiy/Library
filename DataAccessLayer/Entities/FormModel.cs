using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Class for input model
    /// </summary>
    public class FormModel
    {
        /// <summary>
        /// User id
        /// </summary>
        public int FormModelId { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        [Required(ErrorMessage = "Name was not input")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Incorrect name length")]
        [RegularExpression(@"^[A-Z]{1}[a-z]+", ErrorMessage = "Incorrect symbols in name input")]
        public string Name { get; set; }
        /// <summary>
        /// User surname
        /// </summary>
        [Required(ErrorMessage = "Surname was not input")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Incorrect surname length")]
        [RegularExpression(@"^[A-Z]{1}[a-z]+", ErrorMessage = "Incorrect symbols in surname input")]
        public string Surname { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "Email was not input")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        [Remote("ValidateEmail", "Questionnary")]
        public string Email { get; set; }
        /// <summary>
        /// User gender
        /// </summary>
        [Required]
        public string Gender { get; set; }
        /// <summary>
        /// Do user recieve paper distribution
        /// </summary>
        public bool Paper { get; set; }
        /// <summary>
        /// Does user recieve online distribution
        /// </summary>
        public bool Online { get; set; }
    }
}