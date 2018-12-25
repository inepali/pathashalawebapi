using com.pathshala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.pathshala.Controllers
{
    public class LookupController : BaseController
    {
        // GET: Lookup
        public ActionResult Index()
        {
            IEnumerable<Lookup> lookups = (from lkup in DB.Lookups
                                           select lkup).ToList();

            return View(lookups);
        }

        // GET: Lookup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lookup/Create
        public ActionResult Create()
        {
            return View(new Lookup());
        }

        // POST: Lookup/Create
        [HttpPost]
        public ActionResult Create(Lookup model)
        {
            try
            {

                TryUpdateModel<Lookup>(model);
                DB.Lookups.InsertOnSubmit(model);
                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lookup/Edit/5
        public ActionResult Edit(int id)
        {
            Lookup lkup = (from lk in DB.Lookups
                           where lk.ID == id
                           select lk).SingleOrDefault();

            return View(lkup);
        }

        // POST: Lookup/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lookup model)
        {
            try
            {
                Lookup lkup = (from lk in DB.Lookups
                               where lk.ID == id
                               select lk).SingleOrDefault();

                TryUpdateModel<Lookup>(lkup);
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
