using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(Constraints.CARD_NUMBER_REGEX)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(Constraints.CARD_CVC_REGEX)]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}