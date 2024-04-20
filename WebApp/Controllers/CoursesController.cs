using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.ViewModels.Courses;

namespace WebApp.Controllers
{
    [Authorize]
    public class CoursesController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpGet]
        public async Task<IActionResult> Index(string category = "", string searchQuery = "")
        {
            var categoriesResponse = await _http.GetAsync("https://localhost:7154/api/categories");
            var jsonCategories = await categoriesResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(jsonCategories);

            var coursesResponse = await _http.GetAsync($"https://localhost:7154/api/courses?category={category}&searchQuery={searchQuery}");

            var jsonCourses = await coursesResponse.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonCourses);

            var viewModel = new CourseIndexViewModel
            {
                Categories = categories,
                Courses = courses
            };

            return View(viewModel);
        }

    }
}
