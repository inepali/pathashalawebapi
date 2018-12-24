using com.pathshala.Models;
using com.pathshala.Models.Dto;
using com.pathshala.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Person = com.pathshala.Enums.Person;

namespace com.pathshala.Controllers
{
    public class TeacherController : BaseController
    {


        // GET: Teacher
        public ActionResult Index()
        {
            IEnumerable<Models.Teacher> teachers = from t in DB.Teachers
                                                   select t;

            return View(teachers.ToList());
        }



        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Teacher/Create
        public ActionResult Create()
        {
            TeacherModel model = new TeacherModel();
            model.Teacher = new Teacher();



            model.Schools = Utility.getSchoolsNameValue();

            return View(model);
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(TeacherModel model)
        {
            try
            {
                model.Teacher.Person.PersonType = (int)Person.Teacher;

                DB.Teachers.InsertOnSubmit(model.Teacher);

                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {

            TeacherModel model = new TeacherModel();
            model.Teacher = (from t in DB.Teachers
                             where t.ID == id
                             select t).FirstOrDefault();

            model.Schools = Utility.getSchoolsNameValue();

            return View(model);

        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeacherModel model)
        {

            try
            {

                Teacher teacher = (from t in DB.Teachers
                                   where t.ID == id
                                   select t).SingleOrDefault();

                UpdateModel(teacher, "Teacher");

          
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
