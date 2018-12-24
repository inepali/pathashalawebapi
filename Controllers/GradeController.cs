using com.pathshala.Models;
using com.pathshala.Models.Dto;
using com.pathshala.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.pathshala.Controllers
{
    public class GradeController : BaseController
    {
        // GET: Grade
        public ActionResult Index()
        {
            IEnumerable<Models.Grade> grades = from g in DB.Grades
                                                   select g;

            return View(grades.ToList());
        }

        // GET: Grade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grade/Create
        public ActionResult Create()
        {
            GradeModel model = new GradeModel();

            model.Grades = Utility.getLookupByName("GRADE");

            model.Teachers = Utility.getTeachersNameValue();


            model.Schools = Utility.getSchoolsNameValue();
           

            return View(model);
        }

        // POST: Grade/Create
        [HttpPost]
        public ActionResult Create(Grade grade)
        {
            try
            {
                DB.Grades.InsertOnSubmit(grade);
                DB.SubmitChanges();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Grade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
