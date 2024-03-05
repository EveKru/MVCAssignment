using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult SignUp()
    {
        var model = new SignUpModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult SignUp(SignUpModel model)
    {
        if (!ModelState.IsValid) {
            return View(model);
        }
        else { return RedirectToAction("Account", "Index"); }
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        var model = new SignInModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult SignIn(SignInModel model)
    {
        if (!ModelState.IsValid) 
        {
            model.ErrorMessage = "You must enter an email and password";
            return View(model);
        }
        
        // service if true return "redirecttoaction" else errormessage "incorrect email or password"
        else { return RedirectToAction("Account", "Index"); }
    }
}

