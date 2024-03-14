namespace WebApp.Models;

public class AccountModel
{

    public AccountDetailsModel DetailsInfoModel { get; set; } = new AccountDetailsModel()
    {
        //not working
        ProfileImage = "images/newprofileimage.svg",

        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@domain.com"
    };

    public AccountAdressModel AdressInfoModel { get; set; } = new AccountAdressModel();

}
