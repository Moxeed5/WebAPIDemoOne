﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemoOne.Data;
using WebAPIDemoOne.Models.Repositories;

namespace WebAPIDemoOne.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        private ApplicationDbContext db;

        public Shirt_HandleUpdateExceptionsFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;   
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if(int.TryParse(strShirtId, out int shirtId))
            {
                if (db.Shirts.FirstOrDefault(x => x.ShirtId == shirtId) == null)
                {
                    context.ModelState.AddModelError("ShirtID", "Shirt no longer exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }

        }
    }
}
