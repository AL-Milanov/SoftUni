using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Items
{
    public class CreateItemViewModel
    {
        [Required]
        public int CategoryId { get; set; }
    }
}
