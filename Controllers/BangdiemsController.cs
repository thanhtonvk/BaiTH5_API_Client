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
    public class BangdiemsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Bangdiems
        public ActionResult Index()
        {
            return View(db.Bangdiems.ToList());
        }

        // GET: Bangdiems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangdiem bangdiem = db.Bangdiems.Find(id);
            if (bangdiem == null)
            {
                return HttpNotFound();
            }
            return View(bangdiem);
        }

        // GET: Bangdiems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bangdiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masv,Mamh,Diem")] Bangdiem bangdiem)
        {
            if (ModelState.IsValid)
            {
                db.Bangdiems.Add(bangdiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangdiem);
        }

        // GET: Bangdiems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangdiem bangdiem = db.Bangdiems.Find(id);
            if (bangdiem == null)
            {
                return HttpNotFound();
            }
            return View(bangdiem);
        }

        // POST: Bangdiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masv,Mamh,Diem")] Bangdiem bangdiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangdiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangdiem);
        }

        // GET: Bangdiems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bangdiem bangdiem = db.Bangdiems.Find(id);
            if (bangdiem == null)
            {
                return HttpNotFound();
            }
            return View(bangdiem);
        }

        // POST: Bangdiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bangdiem bangdiem = db.Bangdiems.Find(id);
            db.Bangdiems.Remove(bangdiem);
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
