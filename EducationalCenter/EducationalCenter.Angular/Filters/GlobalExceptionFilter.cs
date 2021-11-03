using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Net;

namespace EducationalCenter.Angular.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                LogContext.PushProperty(PropertyNames.LogType, (int)LogType.Exception);
                LogContext.PushProperty(PropertyNames.TypeException, context.Exception.GetType().FullName);
                LogContext.PushProperty(PropertyNames.Message, context.Exception.Message);
                LogContext.PushProperty(PropertyNames.StackTrace, context.Exception.StackTrace);
                LogContext.PushProperty(PropertyNames.Source, context.Exception.Source);
                LogContext.PushProperty(PropertyNames.TargetSite, context.Exception.TargetSite.ToString());

                Log.Error(context.Exception, "Exception in method {ErrorMethod}", context.ActionDescriptor.DisplayName);

                var statusCode = (int) HttpStatusCode.InternalServerError;
                var details = ErrorMessages.InternalServerError;

                SendResponseToClient(context, statusCode, details);

                context.ExceptionHandled = true;
            }
        }

        private void SendResponseToClient(ExceptionContext context, int statusCode, string errorMessage)
        {
            var response = context.HttpContext.Response;

            response.StatusCode = statusCode;
            response.ContentType = "application/json";

            var result = JsonConvert.SerializeObject(new
            {
                details = errorMessage,
                statusCode = statusCode
            }, Formatting.None);

            response.WriteAsync(result);
        }
    }
}
