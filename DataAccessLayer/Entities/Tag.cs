using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

    }
}
