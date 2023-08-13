using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemoOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        
        public string GetShirts()
        {
            return "Reading all shirts";
        }

        [HttpGet("{id}")]

        public string GetShirtById(int id, [FromHeader (Name = "Color")] string color)
        {
            return $"Reading shirt {id} color: {color}";
        }

        [HttpPost]
        
        public string CreateShirt()
        {
            return "Created shirt";
        }

        [HttpPut("{id}")]
        
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }

        [HttpDelete("{id}")]
        
        public string DeleteShirt(int id)
        {
            return $"Deleted shirt: {id}";
        }
    }
}
