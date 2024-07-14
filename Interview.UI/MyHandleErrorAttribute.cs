using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interview.UI
{
    public class MyHandleErrorAttribute:HandleErrorAttribute
    {
       private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled)
            {
                return;
            }
            logger.Error(filterContext.Exception, "Unhandled exceptionmy");
            filterContext.ExceptionHandled = true;               
            var errorInfo = new HandleErrorInfo(filterContext.Exception,
                                                filterContext.RouteData.Values["controller"].ToString(),
                                                filterContext.RouteData.Values["action"].ToString());
                       
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(errorInfo)
            };
            
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
         }
           
    }
}