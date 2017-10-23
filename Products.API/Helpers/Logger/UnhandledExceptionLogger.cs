using NLog;
using Products.Service.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Products.API.Helpers.Logger
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public override void Log(ExceptionLoggerContext context)
        {
            if (context.Exception is NotFoundException) return;

            Logger.Log(
                LogLevel.Error,
                context.Exception,
                RequestToString(context.Request),
                context.RequestContext.RouteData.Values);
        }

        private static string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();
            if (request.Method != null)
                message.Append(request.Method);

            if (request.RequestUri != null)
                message.Append(" ").Append(request.RequestUri);

            return message.ToString();
        }
    }
}