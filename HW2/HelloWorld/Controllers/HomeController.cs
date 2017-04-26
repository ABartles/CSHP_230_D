using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Action Method corisponding to the two links on the "Index" view
        // User is making a request or  "HttpGET" aka GET
        public ActionResult RsvpForm()
        {
            return View();
        }

        // Action Method corisponding to the submit button on "RsvpForm"
        // User is pushing data or "HttpPost" 
        // 1st Parameter: a model, 2nd Parameter: the model data
        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            //  if statement added as part of validation to prevent progress to next pg
            if (ModelState.IsValid)
            {
                // 1st Parameter: is the view (displayed), 2nd Parameter: is the model data 
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }


    }
}