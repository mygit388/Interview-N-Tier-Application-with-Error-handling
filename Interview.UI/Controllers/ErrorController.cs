using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview.UI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult General()
        {
           return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}