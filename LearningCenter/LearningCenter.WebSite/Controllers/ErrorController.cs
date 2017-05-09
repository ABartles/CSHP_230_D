using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningCenter.WebSite.Controllers
{
    public class ErrorController : Controller
    {
        // ---- Error Handler ----
        public ActionResult Error()
        {
            return View();
        }
    }
}