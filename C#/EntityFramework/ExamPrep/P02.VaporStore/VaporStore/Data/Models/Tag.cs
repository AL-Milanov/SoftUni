﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            GameTags = new List<GameTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<GameTag> GameTags { get; set; }
    }
}
