using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaiTH5.Models;

namespace BaiTH5.Controllers
{
    public class SinhViensController : Controller
    {
        private string baseUrl = "https://localhost:44371/api/";
        private DBContext db = new DBContext();

        // GET: SinhViens
        public ActionResult Index()
        {
            IEnumerable<SinhVien> list = new List<SinhVien>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync("SinhVien").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var task = responseMessage.Content.ReadAsAsync<IEnumerable<SinhVien>>();
                    task.Wait();
                    list = task.Result;
                }
            }
            
            return View(list);
        }

        // GET: SinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SinhVien sinhVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync($"SinhVien?id={id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var task = responseMessage.Content.ReadAsAsync<SinhVien>();
                    task.Wait();
                    sinhVien = task.Result;
                }
            }
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masv,Ten_sv,GioiTinh,DiaChi,NgaySinh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var postTask = client.PostAsJsonAsync<SinhVien>("SinhVien", sinhVien);
                    postTask.Wait();
                    var result = postTask.Result;
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
          
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync($"SinhVien?id={id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var task = responseMessage.Content.ReadAsAsync<SinhVien>();
                    task.Wait();
                    sinhVien = task.Result;
                }
            }
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masv,Ten_sv,GioiTinh,DiaChi,NgaySinh")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var putTask = client.PutAsJsonAsync<SinhVien>("SinhVien", sinhVien);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return  RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }
               
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync($"SinhVien?id={id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var task = responseMessage.Content.ReadAsAsync<SinhVien>();
                    task.Wait();
                    sinhVien = task.Result;
                }
            }
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = client.DeleteAsync("SinhVien?id={id}");
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
