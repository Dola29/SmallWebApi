using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallApi.Helpers
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> logger;
        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogError("OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogError("OnActionExecuted");
        }

    }
}