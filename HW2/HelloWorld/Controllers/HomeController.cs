using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;    // Added to allow access model data from "Product"
using System.Web.UI;    // Added as caching exercise 

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // [Logging]   // Added the action filter attribute to implment Logging Attribute Class
        // [AuthorizeIPAddress] // Added the action filter attribute to check IP 
        public ActionResult Index()
        {
            /*
            // Induce Error
            int x = 1;  // add me
            x = x / (x - 1); // add me
            */

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

        // =======================================
        // Code related to Product/Products Views
        
        public ActionResult Product()
        {
            /*
            // Hard Coded data for testing
            var myProduct = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "water-sports",
                Price = 200m,
            };

            return View(myProduct);
            */

            // Added as part of Autofac implementation
            return View(productRepository.Products.First());
        }


        /*
          [OutputCache(Duration = 15, Location = OutputCacheLocation.Any, VaryByParam = "none")]
         * The code line above this comment caches the products data for 15 sec after initial use
         * The use of ".Any" defines the location. Due to some users not allowing caching Any was used
         * Line was commented out due to prefered cashing in repository
         */
        public ActionResult Products()
        {
            /*
            // Hard Coded data for testing
            var products = new Product[]
            {
                new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount = 15},
                new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount = 10},
                new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount = 1},
                new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount = 0},
            };

            return View(products);
            */

            // Added as part of Autofac implementation
            return View(productRepository.Products);
        }
        //====================================

        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //====================================
        
        // Method for session state
        public PartialViewResult IncrementCount()
        {
            int count = 0;

            // Check if MyCount exists
            if (Session["MyCount"] != null)
            {
                count = (int)Session["MyCount"];
                count++;
            }

            // Create the MyCount session variable
            Session["MyCount"] = count;

            return new PartialViewResult();
        }

        //====================================
        // kinda worthless as far as login (session excercise)
        //Login Action
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            Session["UserName"] = loginModel.UserName;  // start a session
            return RedirectToAction("Index");
        }

        // Logoff Action
        public ActionResult Logoff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }

        // Display login name, will need ot call on the partial view
        public PartialViewResult DisplayLoginName()
        {
            return new PartialViewResult();
        }
        //====================================

        // Setting Cookie
        public ActionResult SetCookie()
        {
            // Name the cookie as MyCookie for later retrieval
            var cookie = new HttpCookie("MyCookie");

            // This cookie will expire about one minute, depends on the browser
            cookie.Expires = DateTime.Now.AddMinutes(1);

            // This cookie will have a simple string value of myUserName
            // but it can be any kind of object.
            cookie.Value = "myUserName";

            // Add the cookie to the response to send it to the browser
            HttpContext.Response.Cookies.Add(cookie);

            return View(cookie);
        }

        //Reading Cookies
        public ActionResult GetCookie()
        {
                return View(HttpContext.Request.Cookies["MyCookie"]);
        }
        //====================================

        // Security
        [Authorize]     // This attribute validates user is authorized (ie. in db)
        [IsAdministrator]   // This attribute validates user is an admin
        public ActionResult Notes()
        {
            return View();
        }
    }
}