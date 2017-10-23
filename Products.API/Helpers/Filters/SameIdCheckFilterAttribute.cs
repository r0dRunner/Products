using Products.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Products.API.Helpers.Filters
{
    public class SameIdCheckFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var id = context.ActionArguments.ElementAt(context.ActionArguments.Count - 2).Value as Guid?;
            var dto = context.ActionArguments.ElementAt(context.ActionArguments.Count - 1).Value as BaseDTO;

            if (dto != null
                && Guid.Empty != dto.Id
                && dto.Id != id)
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Location and resource Ids do not match.");
            }
        }
    }
    
    
}