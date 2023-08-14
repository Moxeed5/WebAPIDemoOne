using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemoOne.Models;
using WebAPIDemoOne.Models.Repositories;

namespace WebAPIDemoOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        

        [HttpGet]
        
        public IActionResult GetShirts()
        {
            return Ok("Reading all shirts");
        }

        [HttpGet("{id}")]

        public IActionResult GetShirtById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null)
                return NotFound();

            return Ok(shirt);
        }

        [HttpPost]
        
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok("Created shirt");
        }

        [HttpPut("{id}")]
        
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }

        [HttpDelete("{id}")]
        
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleted shirt: {id}");
        }
    }
}
