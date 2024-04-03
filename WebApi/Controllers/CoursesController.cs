using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(CourseRepository courseRepository) : ControllerBase
    {
        private readonly CourseRepository _courseRepository = courseRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseRepository.GetAllAsync();
            if (result.Any()) {
                return Ok(result);
            }
            return NotFound();
        }




    }
}
