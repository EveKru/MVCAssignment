using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AccountAdressModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Adress", Prompt = "Enter your adress")]
        [Required(ErrorMessage = "Required")]
        public string AdressLine_1 { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Second adress", Prompt = "Enter your second adress")]
        public string? AdressLine_2{ get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Postal code", Prompt = "Enter your postal code")]
        [Required(ErrorMessage = "Required")]
        public string PostalCode { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "City", Prompt = "Enter your city")]
        [Required(ErrorMessage = "Required")]
        public string City { get; set; } = null!;
    }
}
