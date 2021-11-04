using BookShop.Models.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<BookCategory>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(Restriction.CATEGORY_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
