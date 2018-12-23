using com.pathshala.Models;
using com.pathshala.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Person = com.pathshala.Enums.Person;

namespace com.pathshala.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {

            IEnumerable<Student> students = from s in DB.Students
                                            select s;

            return View(students.ToList());

        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentModel model = new StudentModel();
            model.Student = new Student();

            IEnumerable<NameValuePairModel> schools = from s in DB.Schools
                                                      select new NameValuePairModel
                                                      {
                                                          Name = s.Name,
                                                          Value = s.ID
                                                      };

            model.Schools = schools;

            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            try
            {
                //Teacher teacher = new Teacher();


                //UpdateModel()
                //UpdateModel(teacher, collection.Teacher);
                model.Student.Person.PersonType = (int)Person.Student;
                //DB.Persons.InsertOnSubmit(model.Teacher.Person);

                //                model.Teacher.PersonID = model.Teacher.Person.ID;

                DB.Students.InsertOnSubmit(model.Student);

                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
