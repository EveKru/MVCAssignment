using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("SignIn", "Auth");
        }

        var userEntity = await _userManager.GetUserAsync(User);
        var model = new AccountModel()
        {
            User = userEntity!
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult DetailsInfo(AccountDetailsModel model)
    {
        //service update new model
        return RedirectToAction(nameof(Details));
    }

    [HttpPost]
    public IActionResult AdressInfo(AccountAdressModel model)
    {
        //service update new model
        return RedirectToAction(nameof(Details));
    }
}

