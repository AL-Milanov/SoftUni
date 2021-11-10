namespace FastFood.Core.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeViewModel
    {
        [Required]
        public int PositionId { get; set; }

        [Required]
        public string PositionName { get; set; }
    }
}
