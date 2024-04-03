using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
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
                var url = "https://localhost:7154/api/subscribers?key=YTBiYWU4MmQtOTU0Zi00OWU2LWJmYmItNWU3MWZmMTE1YTZk";

                // Serialize subscribeModel to JSON
                var json = JsonConvert.SerializeObject(subscribeModel);
                // Create a StringContent object with JSON data
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Send POST request with JSON data
                var response = await http.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("Success", "You have been subscribed.");
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    ModelState.AddModelError("Errors", "You have already subscribed.");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ModelState.AddModelError("Errors", "Unauthorized. Please contact web admin");
                }
                else
                {
                    // Handle other status codes
                    ModelState.AddModelError("Errors", $"Server returned status code: {(int)response.StatusCode} {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                ModelState.AddModelError("Errors", $"HTTP request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError("Errors", $"An error occurred: {ex.Message}");
            }
        }
        else { ModelState.AddModelError("Errors", "Invalid Email"); }
        return View(subscribeModel);
    }
}
