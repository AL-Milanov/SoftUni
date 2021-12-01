using BookShop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public   class Author
    {
        public Author()
        {
            AuthorsBooks = new List<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Constraints.AUTHOR_FIRSTNAME_MAX_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength (Constraints.AUTHOR_LASTNAME_MAX_LENGTH)]
        public string LastName { get; set; }

        [Required]
        [StringLength(Constraints.AUTHOR_PHONE_MAX_LENGTH)]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
