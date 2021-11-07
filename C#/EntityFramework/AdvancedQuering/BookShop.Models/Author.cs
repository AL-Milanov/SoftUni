using BookShop.Models.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        
        [StringLength(Restriction.AUTHOR_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Restriction.AUTHOR_NAME_LENGTH)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
