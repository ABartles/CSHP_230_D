using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateCard
        public ActionResult CardForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CardForm(Models.CardFill cardfill)
        {
            // If Statment added for entry validation
            if (ModelState.IsValid)
            {
                return View("CardSent", cardfill);
            }
            else
            {
                return View();
            }
        }
    }
}