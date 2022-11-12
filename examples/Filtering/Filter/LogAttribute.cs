using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtering.Filter
{
    public class LogAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Action Çalıştıktan sonra
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            // Action Çalıştırken

        }
    }
}