using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Common;
using VaporStore.Data.Enum;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new List<Purchase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Constraints.CARD_NUMBER_LENGTH)]
        public string Number { get; set; }

        [Required]
        [StringLength(Constraints.CARD_CVC_LENGTH)]
        public string Cvc { get; set; }

        public CardType Type{ get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<Purchase> Purchases { get; set; }
    }
}