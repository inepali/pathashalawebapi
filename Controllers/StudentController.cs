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
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {

            IEnumerable<Student> students = from s in DB.Students
                                            select s;

            return View(students.ToList());

        }

        // GET: Student/By/{School ID}
        public ActionResult School(int id)
        {
            IEnumerable<Student> students = from t in DB.Students
                                                   where t.SchoolID == id
                                            select t;

            return View("Index", students.ToList());
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

            model.Schools = Utility.getSchoolsNameValue();

            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            try
            {

                model.Student.Person.PersonType = (int)Person.Student;

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
            StudentModel model = new StudentModel();
            model.Student = (from s in DB.Students
                             where s.ID == id
                             select s).FirstOrDefault();

            model.Schools = Utility.getSchoolsNameValue();
            model.Grades = Utility.getGrades();

            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel model)
        {
            try
            {

                Student student = (from s in DB.Students
                                   where s.ID == id
                                   select s).SingleOrDefault();

                UpdateModel(student, "Student");

                //if (model.GradeStudent.GradeID != null) {
                //    GradeStudent grdStdnt = (from gs in DB.GradeStudents
                //                             where gs.StudentID == id
                //                             select gs).SingleOrDefault();

                //    if (grdStdnt == null)
                //    {
                //        grdStdnt = new GradeStudent();
                //        grdStdnt.GradeID = model.GradeStudent.GradeID;
                //        grdStdnt.StudentID = id;
                //        DB.GradeStudents.InsertOnSubmit(grdStdnt);
                //    }
                //    else {
                //        grdStdnt.GradeID = model.GradeStudent.GradeID;
                //    }

                //   // DB.SubmitChanges();

                //}

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
