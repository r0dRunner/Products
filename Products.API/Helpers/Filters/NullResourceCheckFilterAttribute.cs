using Products.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Products.API.Helpers.Filters
{
    public class NullResourceCheckFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var dto = context.ActionArguments.ElementAt(context.ActionArguments.Count - 1).Value as BaseDTO;

            if (dto == null)
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "No resource specified.");
            }
        }
    }
}