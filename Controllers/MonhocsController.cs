using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BaiTH5.Models;

namespace BaiTH5.Controllers
{
    public class MonhocsController : Controller
    {
        private DBContext db = new DBContext();
        private string baseUrl = "https://localhost:44371/api/";

        public Monhoc GetMonHoc(int id)
        {
            Monhoc monhoc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"Monhoc?id={id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var getTask = response.Content.ReadAsAsync<Monhoc>();
                    getTask.Wait();
                    monhoc = getTask.Result;
                }
            }

            return monhoc;
        }
        // GET: Monhocs
        public ActionResult Index()
        {
            IEnumerable<Monhoc> model = new List<Monhoc>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("MonHoc").Result;
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsAsync<IEnumerable<Monhoc>>();
                    task.Wait();
                    model = task.Result;
                }
            }
            return View(model);
        }

        // GET: Monhocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Monhoc monhoc = GetMonHoc(id.Value);
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync("MonHoc", monhoc);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }
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

            Monhoc monhoc = GetMonHoc(id.Value);
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
                using (var client = new HttpClient())
                {
                    var response = client.PutAsJsonAsync("MonHoc", monhoc);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
               
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

            Monhoc monhoc = GetMonHoc(id.Value);
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
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"MonHoc?id={id}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
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
