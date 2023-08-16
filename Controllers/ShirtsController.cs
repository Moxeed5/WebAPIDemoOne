using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using WebAPIDemoOne.Data;
using WebAPIDemoOne.Filters;
using WebAPIDemoOne.Filters.ActionFilters;
using WebAPIDemoOne.Filters.ExceptionFilters;
using WebAPIDemoOne.Models;
using WebAPIDemoOne.Models.Repositories;

namespace WebAPIDemoOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        
        public IActionResult GetShirts()
        {
            return Ok(db.Shirts.ToList());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]

        public IActionResult GetShirtById(int id)
        {

            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById), 
                new { id = shirt.ShirtId},
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]

        public IActionResult UpdateShirt(int id, Shirt shirt)
        {

            ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);

            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }
    }
}
