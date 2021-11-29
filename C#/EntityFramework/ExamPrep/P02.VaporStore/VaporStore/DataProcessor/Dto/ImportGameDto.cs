using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportGameDto
    {
        public ImportGameDto()
        {
            Tags = new List<string>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), Constraints.GAME_PRICE_MIN_VALUE, Constraints.GAME_PRICE_MAX_VALUE)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(1)]
        public List<string> Tags{ get; set; }
    }
}
