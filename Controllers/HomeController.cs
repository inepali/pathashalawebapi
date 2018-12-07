using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    /// <summary>
    /// Home Controlller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Home page
        /// </summary>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //this is a comment

            return View();
        }
    }
}
