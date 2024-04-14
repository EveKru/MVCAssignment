using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(DataContext dataContext) : ControllerBase
    {
        private readonly DataContext _dataContext = dataContext;

        [HttpGet]
        public async Task<IActionResult> GetAll(string category = "", string searchQuery = "")
        {
            var query = _dataContext.Courses.Include(i => i.Category).AsQueryable();
            if (!string.IsNullOrWhiteSpace(category) && category != "all") {
                query = query.Where(x => x.Category!.CategoryName == category);
            }
            if (!string.IsNullOrEmpty(searchQuery)) {
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));
            }
            query = query.OrderByDescending(o => o.LastUpdated);
            var courses = await query.ToListAsync();
            return Ok(courses);
        }
    }
}
