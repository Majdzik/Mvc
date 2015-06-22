using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MajdzikMvc.Controllers
{
    public class BuilderController : _Controller
    {
        // GET: Builder
        public ActionResult Index()
        {
            return View();
        }

        // GET: Builder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Builder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Builder/Create
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

        // GET: Builder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Builder/Edit/5
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

        // GET: Builder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Builder/Delete/5
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
