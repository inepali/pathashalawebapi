using com.pathshala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.pathshala.Controllers
{
    public class SchoolController : BaseController
    {
        // GET: School
        public ActionResult Index()
        {
            IEnumerable<School> schools = from sch in DB.Schools
                                          select sch;

            return View(schools.ToList());
        }

        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: School/Create
        public ActionResult Enroll()
        {
            return View(new School());
        }



        // POST: School/Create
        [HttpPost]
        public ActionResult Enroll(School model)
        {
            try
            {
                model.IsActive = false;
                DB.Schools.InsertOnSubmit(model);
                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return View();
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            School school = (from s in DB.Schools
                             where s.ID == id
                             select s).FirstOrDefault();

            return View(school);
        }

        // POST: School/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, School model)
        {
            try
            {
                School school = (from s in DB.Schools
                                 where s.ID == id
                                 select s).FirstOrDefault();

                TryUpdateModel<School>(school);
                DB.SubmitChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
