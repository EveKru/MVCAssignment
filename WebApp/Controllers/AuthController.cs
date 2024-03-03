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
        else { return RedirectToAction("SignIn", "Auth"); }
    }
}
