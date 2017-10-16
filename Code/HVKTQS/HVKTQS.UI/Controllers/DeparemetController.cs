using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HVKTQS.UI.Controllers
{
    public class DeparemetController : Controller
    {
        // GET: Deparemet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deparemet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deparemet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deparemet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deparemet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deparemet/Edit/5
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

        // GET: Deparemet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deparemet/Delete/5
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
