using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class CoursesController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _http.GetAsync("https://localhost:7154/api/courses");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(json);

            return View(data);
        }
    }
}
