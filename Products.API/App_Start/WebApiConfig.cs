using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Products.API.Helpers.Logger;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Products.API.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

            //Logger
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            //Versioning
            config.AddApiVersioning(a => {
                a.DefaultApiVersion = 
                    ApiVersion.Parse(WebConfigurationManager.AppSettings["Versioning.Default"]);
                a.AssumeDefaultVersionWhenUnspecified = true;
                a.ApiVersionReader = 
                    new QueryStringApiVersionReader(
                        WebConfigurationManager.AppSettings["Versioning.ParameterName"]);
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
