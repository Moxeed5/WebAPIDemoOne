﻿using Microsoft.AspNetCore.Http.HttpResults;
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
        [TypeFilter (typeof(Shirt_ValidateShirtIdFilterAttribute))]

        public IActionResult GetShirtById(int id)
        {
      

            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateShirtFilterAttribute))]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            this.db.Shirts.Add(shirt);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(GetShirtById), 
                new { id = shirt.ShirtId},
                shirt);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]

        public IActionResult UpdateShirt(int id, Shirt shirt)
        {

            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]

        public IActionResult DeleteShirt(int id)
        {
            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;

            db.Shirts.Remove(shirtToDelete);
            db.SaveChanges();

            return Ok(shirtToDelete);
        }
    }
}
