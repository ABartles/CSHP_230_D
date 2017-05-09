using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenter.Business;
using LearningCenter.WebSite.Models;

namespace LearningCenter.WebSite.Controllers
{


    public class HomeController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IClassManager classManager;

        public HomeController(IUserManager userManager, IClassManager classManager)
        {
            this.userManager = userManager;
            this.classManager = classManager;
        }

       //---- Enroll ----
        
        public ActionResult Enroll()
        {
            var classes = classManager.ClassList()
                .Select(t => new LearningCenter.WebSite.Models.ClassModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price
                }).ToArray();

            var model = new ClassViewModel
            {
                Classes = classes
            };

            return View(model);
        }


        /*
        [HttpPost]
        public ActionResult AddClass()
        {
            // Write back to db
            //return Redirect();
        }
        */


        // ---- User Class List ---

        public ActionResult EnrolledClasses()
        {
            return View();
        }

        // ----ClassList----

        public ActionResult ClassList()
        {
            var classes = classManager.ClassList()
                .Select(t => new LearningCenter.WebSite.Models.ClassModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price
                }).ToArray();

            var model = new ClassViewModel
            {
                Classes = classes
            };

            return View(model);
        }

        //----Register----

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel, string Email, string Password)
        {
            var user = userManager.Register(Email , Password);

            

            return View(user);
        } 


        //----LogIn----
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new LearningCenter.WebSite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        //----LogOff----

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        //----Default----

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Under Construction.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Andrew Bartles";

            return View();
        }


    
    }
}