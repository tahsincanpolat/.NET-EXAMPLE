using Filtering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtering.Filter
{
    public class LogAttribute : FilterAttribute, IActionFilter, IResultFilter, IExceptionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogVeri.Loglar.Add(
                new LogBilgi
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = filterContext.ActionDescriptor.ActionName,
                    IslemTarihi = DateTime.Now,
                    Tip = "Girildekten Sonra"
                }
            );
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogVeri.Loglar.Add(
                new LogBilgi
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = filterContext.ActionDescriptor.ActionName,
                    IslemTarihi = DateTime.Now,
                    Tip = "Girildekten Önce"
                }
            );

        }

        public void OnException(ExceptionContext filterContext)
        {
            LogVeri.Loglar.Add(
                new LogBilgi
                {
                    Controller = filterContext.RouteData.Values["controller"].ToString(),
                    Action = filterContext.RouteData.Values["action"].ToString(),
                    IslemTarihi = DateTime.Now,
                    Tip = "Önce"
                }
            );
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogVeri.Loglar.Add(
               new LogBilgi
               {
                   Controller = filterContext.RouteData.Values["controller"].ToString(),
                   Action = filterContext.RouteData.Values["action"].ToString(),
                   IslemTarihi = DateTime.Now,
                   Tip = "Sonuçtan sonra"
               }
           );
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogVeri.Loglar.Add(
               new LogBilgi
               {
                   Controller = filterContext.RouteData.Values["controller"].ToString(),
                   Action = filterContext.RouteData.Values["action"].ToString(),
                   IslemTarihi = DateTime.Now,
                   Tip = "Sonuçtan önce"
               }
           );
        }
    }
}