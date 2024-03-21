using Infrastructure.Entities;

namespace WebApp.Models;

public class AccountModel
{
    public UserEntity User { get; set; } = null!;

    public AccountDetailsModel DetailsInfoModel { get; set; } = new AccountDetailsModel();

    public AccountAdressModel AdressInfoModel { get; set; } = new AccountAdressModel();

}
