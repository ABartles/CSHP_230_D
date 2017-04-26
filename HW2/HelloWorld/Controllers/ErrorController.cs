using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        // Added to display error view once captured
        public ActionResult Error()
        {
            return View();
        }
    }
}