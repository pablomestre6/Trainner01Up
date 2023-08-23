using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project01.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
