using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.pathshala.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(Models.Student student)
        {
            if (ModelState.IsValid)
            {
                //RegMVCEntities db = new RegMVCEntities();
                //db.tblRegistrations.Add(obj);
                //db.SaveChanges();
            }
            return View(student);
        }


        public ActionResult CreateTeacher()
        {
            return View();
        }

    }
}