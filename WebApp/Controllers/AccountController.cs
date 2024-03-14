using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            var model = new AccountModel();
            return View(model);
            // service, (get new details from detailsinfo and adressinfo)
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
}
