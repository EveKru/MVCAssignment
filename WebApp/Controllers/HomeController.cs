using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SubscribeModel subscribeModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                using var http = new HttpClient();

                var content = new StringContent(JsonConvert.SerializeObject(subscribeModel), Encoding.UTF8, "application/json");
                var respone = await http.PostAsync("https://localhost:7154/subscribers", content);

                if (respone.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("Success", "You have been subscribed.");
                }
                if (respone.StatusCode == System.Net.HttpStatusCode.Conflict) 
                {
                    ModelState.AddModelError("Errors", "You have already subscribed.");
                }
            }
            catch { ModelState.AddModelError("Errors", "Unable to contact the server. Please try again later."); }
        }
        else { ModelState.AddModelError("Errors", "Invalid Email"); }
        return View(subscribeModel);
    }
}
