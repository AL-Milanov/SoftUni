using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(Constraints.USER_FULLNAME_REGEX)]
        public string FullName { get; set; }

        [Required]
        [StringLength(Constraints.USER_NAME_MAX_LENGTH, MinimumLength = Constraints.USER_NAME_MIN_LENGTH)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public List<ImportCardDto> Cards{ get; set; }
    }
}
