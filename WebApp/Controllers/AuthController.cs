using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace WebApp.Controllers;

public class AuthController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;


    [HttpGet]
    public IActionResult SignUp()
    {
        var model = new SignUpModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        if (!ModelState.IsValid) {
            return View(model);
        }
        else {
            await _userService.CreateUserAsync(model);
            return RedirectToAction("Details", "Account"); 
        }
    }


    [HttpGet]
    public IActionResult SignIn()
    {
        var model = new SignInModel();
        return View(model);
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
            var result = await _userService.SignInUserAsync(model);
            if (result != null)
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
}

