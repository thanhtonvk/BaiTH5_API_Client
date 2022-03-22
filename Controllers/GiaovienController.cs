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
    public class GiaovienController : Controller
    {
        string baseURL = "https://localhost:44371/api/";
        DBContext db = new DBContext();
        // GET: Giaovien
        public ActionResult Index()
        {
           
            return View(db.Giaoviens.ToList());
        }

        // GET: Giaovien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giaovien giaovien = db.Giaoviens.Find(id);
            if (giaovien == null)
            {
                return HttpNotFound();
            }
            return View(giaovien);
        }

        // GET: Giaovien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Giaovien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magv,Tengv,chyennganh,diachi,sdt")] Giaovien giaovien)
        {
            if (ModelState.IsValid)
            {
                db.Giaoviens.Add(giaovien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giaovien);
        }

        // GET: Giaovien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giaovien giaovien = db.Giaoviens.Find(id);
            if (giaovien == null)
            {
                return HttpNotFound();
            }
            return View(giaovien);
        }

        // POST: Giaovien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magv,Tengv,chyennganh,diachi,sdt")] Giaovien giaovien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaovien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaovien);
        }

        // GET: Giaovien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giaovien giaovien = db.Giaoviens.Find(id);
            if (giaovien == null)
            {
                return HttpNotFound();
            }
            return View(giaovien);
        }

        // POST: Giaovien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giaovien giaovien = db.Giaoviens.Find(id);
            db.Giaoviens.Remove(giaovien);
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
