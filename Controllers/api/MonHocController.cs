using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiTH5.Models;

namespace BaiTH5.Controllers.api
{
    public class MonHocController:ApiController
    {
        private DBContext db = new DBContext();

        public IQueryable<Monhoc> Get()
        {
            return db.Monhocs;
        }

        public Monhoc Get(int id)
        {
            return db.Monhocs.Find(id);
        }

        public int Post([FromBody] Monhoc monhoc)
        {
            db.Monhocs.Add(monhoc);
            return db.SaveChanges();
        }

        public int Put([FromBody] Monhoc monhoc)
        {
            db.Monhocs.Add(monhoc);
            db.Entry(monhoc).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Monhocs.Remove(db.Monhocs.Find(id));
            return db.SaveChanges();
        }
    }
}