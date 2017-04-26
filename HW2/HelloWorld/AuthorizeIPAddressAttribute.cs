using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;   // Added
using System.Web.Mvc;   // Added
using System.Net;

namespace HelloWorld
{
    public class AuthorizeIPAddressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentRequest = filterContext.HttpContext.Request;

            if(currentRequest.UserHostAddress != "192.168.86.184")
            {
                // Prefered method. Use the ISS standard message. Handled prior to reaching the server. 
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}