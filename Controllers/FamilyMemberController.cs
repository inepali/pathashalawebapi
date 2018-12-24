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
    public class FamilyMemberController : BaseController
    {
        // GET: FamilyMember/{Student ID}
        public ActionResult Index(int id)
        {
            IEnumerable<FamilyMemberStudent> members = from fms in DB.FamilyMemberStudents
                                            where fms.StudentID == id
                                            select fms;
            ViewData.Add("StudentID", id);
            return View(members.ToList());
        }

        // GET: FamilyMember/Create/{Student ID}
        public ActionResult Create(int id)
        {
            FamilyMemberStudentModel fmsm = new FamilyMemberStudentModel();
            
            fmsm.FamilyMemberStudent = new FamilyMemberStudent();
            fmsm.FamilyMemberStudent.StudentID = id;

            fmsm.RelationshipTypes = Utility.getLookupByName("RELATION");

            return View(fmsm);
        }

        // POST: FamilyMember/Create
        [HttpPost]
        public ActionResult Create(FamilyMemberStudentModel model)
        {
            try
            {

                model.FamilyMemberStudent.FamilyMember.Person.PersonType = (int)Person.FamilyMember;

                DB.FamilyMemberStudents.InsertOnSubmit(model.FamilyMemberStudent);

                DB.SubmitChanges();

                return RedirectToAction("Index", new { id = model.FamilyMemberStudent.StudentID});
            }
            catch
            {
                return View();
            }
        }

        // GET: FamilyMember/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FamilyMember/Edit/5
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
    }
}
