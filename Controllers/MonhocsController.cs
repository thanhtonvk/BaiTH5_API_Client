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
    public class MonhocsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Monhocs
        public ActionResult Index()
        {
            return View(db.Monhocs.ToList());
        }

        // GET: Monhocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // GET: Monhocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mamh,Tenmh,chyennganh,Sohoctrinh")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Monhocs.Add(monhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monhoc);
        }

        // GET: Monhocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // POST: Monhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mamh,Tenmh,chyennganh,Sohoctrinh")] Monhoc monhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monhoc);
        }

        // GET: Monhocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monhoc monhoc = db.Monhocs.Find(id);
            if (monhoc == null)
            {
                return HttpNotFound();
            }
            return View(monhoc);
        }

        // POST: Monhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monhoc monhoc = db.Monhocs.Find(id);
            db.Monhocs.Remove(monhoc);
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
