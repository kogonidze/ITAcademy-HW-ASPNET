using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


                context.ExceptionHandled = true;
            }
        }
    }
}
