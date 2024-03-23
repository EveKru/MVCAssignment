using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Factories;
using WebApp.ViewModels.Authentication;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        return View(new SignUpModel());
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        if (!ModelState.IsValid) {
            return View(model);
        }
        else {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == model.Email);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email already exists"); 
                return View(model);
            }
            else
            {
                var userEntity = UserFactory.Create(model);
                var result = await _userManager.CreateAsync(userEntity, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Error", error.Description);
                    }
                    return View(model);
                }

                //var result = await _userManager.CreateAsync(userEntity, model.Password);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("SignIn");
                //}
                //ModelState.AddModelError("Error", "Something went wrong");
                //return View(model);
            }
        }
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        return View(new SignInModel());
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        if (!ModelState.IsValid) 
        {
            model.ErrorMessage = "you must enter a email or password";
            return View(model);
        }
        else {

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }
            else
            {
                model.ErrorMessage = "Incorrect email or password";
                return View(model);
            }
        }
    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");

    }
}

