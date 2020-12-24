using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;


namespace WebApplicationMVC.Controllers
{
    public class IspitController : Controller
    {
        // GET: Ispit
        public ActionResult Index()
        {
            using (DBFModel db = new DBFModel())
            {
                return View(db.Ispit.ToList());
            }
        }
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Ispit ispit)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    db.Ispit.Add(ispit);
                    db.SaveChanges();
                }

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
            using (DBFModel db = new DBFModel())
            {
                return View(db.Ispit.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ispit ispit)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    db.Entry(ispit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

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
            using (DBFModel db = new DBFModel())
            {
                return View(db.Ispit.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    Ispit ispit = db.Ispit.Where(x => x.Id == id).FirstOrDefault();
                    db.Ispit.Remove(ispit);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
