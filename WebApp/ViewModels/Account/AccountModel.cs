using Infrastructure.Entities;

namespace WebApp.ViewModels.Account;

public class AccountModel
{

    public AccountProfileModel ProfileInfoModel { get; set; } = null!;

    public AccountDetailsModel DetailsInfoModel { get; set; } = null!;

    public AccountAdressModel AdressInfoModel { get; set; } = null!;

}
