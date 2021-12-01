using BookShop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDto
    {
        [Required]
        [StringLength(Constraints.AUTHOR_FIRSTNAME_MAX_LENGTH,
            MinimumLength = Constraints.AUTHOR_FIRSTNAME_MIN_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Constraints.AUTHOR_LASTNAME_MAX_LENGTH,
            MinimumLength = Constraints.AUTHOR_LASTNAME_MIN_LENGTH)]
        public string LastName { get; set; }

        [Required]
        [StringLength(Constraints.AUTHOR_PHONE_MAX_LENGTH)]
        [RegularExpression(Constraints.AUTHOR_PHONE_REGEX)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<ImportBookIdsDto> Books{ get; set; }
    }
}
