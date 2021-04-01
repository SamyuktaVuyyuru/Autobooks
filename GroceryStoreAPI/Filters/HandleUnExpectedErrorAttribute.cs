using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Filters
{
    public class HandleUnExpectedErrorAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new Error
            {
                ErrorMessage = "Unknown Error",
                ErrorType = "ERROR"
            };
            context.Result = new ObjectResult(error)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
