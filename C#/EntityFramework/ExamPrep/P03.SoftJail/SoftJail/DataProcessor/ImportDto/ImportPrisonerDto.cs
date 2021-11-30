using SoftJail.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerDto
    {
        [Required]
        [StringLength(Constraints.PRISONER_NAME_MAX_LENGTH,
                MinimumLength = Constraints.PRISONER_NAME_MIN_LENGTH)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(Constraints.PRISONER_NICKNAME_REGEX)]
        public string Nickname { get; set; }

        [Required]
        [Range(Constraints.PRISONER_AGE_MIN_VALUE,
            Constraints.PRISONER_AGE_MAX_VALUE)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(Constraints.PRISONER_BAIL_MIN_VALUE,
            Constraints.PRISONER_BAIL_MAX_VALUE)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public List<ImportMailDto> Mails { get; set; }
    }
}
