using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Account
{
    public class AccountAdressModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Adress line 1", Prompt = "Enter your adress line")]
        [Required(ErrorMessage = "Required")]
        public string AdressLine_1 { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Adress line 2", Prompt = "Enter your second adress line")]
        public string? AdressLine_2 { get; set; }

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
