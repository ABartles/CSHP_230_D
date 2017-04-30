using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;    // Added

namespace HelloWorld.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOut()
        {
            Session["User"] = null; // drops the user from the session once the session is ended
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("~/");
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.LogIn(model.UserName, model.Password);

                if (user != null)
                {
                    Session["User"] = user; // keeps track of the user in the session
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return Redirect(returnUrl);
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        private IUserRepository userRepository; // inject the user repository

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}