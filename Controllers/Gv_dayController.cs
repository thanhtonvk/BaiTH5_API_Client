using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTH5.Models;

namespace BaiTH5.Controllers
{
    public class Gv_dayController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Gv_day
        public ActionResult Index()
        {
            return View(db.Gv_day.ToList());
        }

        // GET: Gv_day/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gv_day gv_day = db.Gv_day.Find(id);
            if (gv_day == null)
            {
                return HttpNotFound();
            }
            return View(gv_day);
        }

        // GET: Gv_day/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gv_day/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magv,Mamh")] Gv_day gv_day)
        {
            if (ModelState.IsValid)
            {
                db.Gv_day.Add(gv_day);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gv_day);
        }

        // GET: Gv_day/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gv_day gv_day = db.Gv_day.Find(id);
            if (gv_day == null)
            {
                return HttpNotFound();
            }
            return View(gv_day);
        }

        // POST: Gv_day/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magv,Mamh")] Gv_day gv_day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gv_day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gv_day);
        }

        // GET: Gv_day/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gv_day gv_day = db.Gv_day.Find(id);
            if (gv_day == null)
            {
                return HttpNotFound();
            }
            return View(gv_day);
        }

        // POST: Gv_day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gv_day gv_day = db.Gv_day.Find(id);
            db.Gv_day.Remove(gv_day);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
