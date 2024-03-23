using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Account;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;

namespace WebApp.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AdressService adressService) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    private readonly AdressService _adressService = adressService;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("SignIn", "Auth");
        }

        var model = new AccountModel();
        model.ProfileInfoModel = await PopulateProfileInfoAsync();
        model.DetailsInfoModel ??= await PopulateAccountDetailsAsync();
        model.AdressInfoModel ??= await PopulateAccountAdressAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Details(AccountModel model)
    {
        if (model.DetailsInfoModel != null)
        {
            if (model.DetailsInfoModel.FirstName != null && model.DetailsInfoModel.LastName != null && model.DetailsInfoModel.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = model.DetailsInfoModel.FirstName;
                    user.LastName = model.DetailsInfoModel.LastName;
                    user.Email = model.DetailsInfoModel.Email;
                    user.PhoneNumber = model.DetailsInfoModel.Phone;
                    user.Bio = model.DetailsInfoModel.Bio;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("Error", error.Description);
                        }
                    }
                }
            }
        }

        if (model.AdressInfoModel != null)
        {
            if (model.AdressInfoModel.AdressLine_1 != null && model.AdressInfoModel.PostalCode != null && model.AdressInfoModel.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var adress = await _adressService.GetAdressAsync(user.Id);
                    if (adress != null)
                    {
                        adress.AdressLine_1 = model.AdressInfoModel.AdressLine_1;
                        adress.AdressLine_2 = model.AdressInfoModel.AdressLine_2;
                        adress.PostalCode = model.AdressInfoModel.PostalCode;
                        adress.City = model.AdressInfoModel.City;

                        var result = await _adressService.UpdateAdressAsync(adress);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Unable to save data.");
                        }
                    }
                    else
                    {
                        adress = new AdressEntity
                        {
                            UserId = user.Id,
                            AdressLine_1 = model.AdressInfoModel.AdressLine_1,
                            AdressLine_2 = model.AdressInfoModel.AdressLine_2,
                            PostalCode = model.AdressInfoModel.PostalCode,
                            City = model.AdressInfoModel.City,
                        };

                        var result = await _adressService.CreateAdressAsync(adress);
                        if (!result)
                        {
                           ModelState.AddModelError("IncorrectValues", "Unable to save data.");
                        }
                    }
                }
            }
        }

        model.ProfileInfoModel = await PopulateProfileInfoAsync();
        model.DetailsInfoModel ??= await PopulateAccountDetailsAsync();
        model.AdressInfoModel ??= await PopulateAccountAdressAsync();

        return View(model);
    }

    public async Task<AccountProfileModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountProfileModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!
        };
    }

    public async Task<AccountDetailsModel> PopulateAccountDetailsAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Bio = user.Bio
        };
    }

    public async Task<AccountAdressModel> PopulateAccountAdressAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var adress = await _adressService.GetAdressAsync(user.Id);
            if (adress != null)
            {
                return new AccountAdressModel
                {
                    AdressLine_1 = adress.AdressLine_1,
                    AdressLine_2 = adress.AdressLine_2,
                    PostalCode = adress.PostalCode,
                    City = adress.City
                };
            }
        }
        return new AccountAdressModel();
    }
}

