using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(SubscriberService subscriberService) : ControllerBase
    {
        private readonly SubscriberService _subscriberService = subscriberService;

        [HttpPost]
        public async Task<IActionResult> Create(SubscriberDto subscriberDto)
        {
            if (subscriberDto != null)
            {
                var exists = await _subscriberService.GetSubscriberByEmailAsync(subscriberDto.Email);
                if (exists == null)
                {
                    var subscriberEntity = new SubscriberEntity { Email = subscriberDto.Email };
                    var result = await _subscriberService.CreateSubscriberAsync(subscriberEntity);
                    if (result) return Created();
                    return Problem("Unable to create subscription.");
                }
                return Conflict("Email is already subscribed.");
            }
            return BadRequest();
        }

        [HttpDelete("ByEmail")]
        public async Task<IActionResult> DeleteByEmail(string email)
        {
            var result = await _subscriberService.GetSubscriberByEmailAsync(email);
            if (result != null)
            {
                await _subscriberService.DeleteSubscriberByEmailAsync(email);
                return Ok();
            }
            return NotFound();
        }
    }
}
