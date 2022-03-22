using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiTH5.Models;

namespace BaiTH5.Controllers.api
{
    public class GiaoVienController:ApiController
    {
        private DBContext db = new DBContext();

        public IQueryable<Giaovien> Get()
        {
            return db.Giaoviens;
        }

        public Giaovien Get(int id)
        {
            return db.Giaoviens.Find(id);
        }
        public int Post([FromBody] Giaovien giaovien)
        {
            db.Giaoviens.Add(giaovien);
            return db.SaveChanges();
        }

        public int Put([FromBody] Giaovien giaovien)
        {
            db.Giaoviens.Add(giaovien);
            db.Entry(giaovien).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Giaoviens.Remove(db.Giaoviens.Find(id));
            return db.SaveChanges();
        }
    }
}