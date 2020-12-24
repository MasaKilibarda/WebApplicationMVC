using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;
namespace WebApplicationMVC.Controllers
{
    public class PredmetController : Controller
    {
        // GET: Predmet
        public ActionResult Index()
        {
            using (DBFModel db = new DBFModel())
            {
                return View(db.Predmet.ToList());
            }
        }

        // GET: Predmet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmet/Create
        [HttpPost]
        public ActionResult Create(Predmet predmet)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    db.Predmet.Add(predmet);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Predmet/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBFModel db = new DBFModel())
            {
                return View(db.Predmet.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Predmet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Predmet predmet)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    db.Entry(predmet).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Predmet/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBFModel db = new DBFModel())
            {
                return View(db.Predmet.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Predmet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBFModel db = new DBFModel())
                {
                    Predmet pred = db.Predmet.Where(x => x.Id == id).FirstOrDefault();
                    db.Predmet.Remove(pred);
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
