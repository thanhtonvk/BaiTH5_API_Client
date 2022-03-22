using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiTH5.Models;

namespace BaiTH5.Controllers.api
{
    public class SinhVienController:ApiController
    {
        private DBContext db = new DBContext();

        public IQueryable<SinhVien> Get()
        {
            return db.SinhViens;
        }

        public SinhVien Get(int id)
        {
            return db.SinhViens.Find(id);
        }

        public int Post([FromBody] SinhVien sinhVien)
        {
            db.SinhViens.Add(sinhVien);
            return db.SaveChanges();
        }

        public int Put([FromBody] SinhVien sinhVien)
        {
            db.SinhViens.Add(sinhVien);
            db.Entry(sinhVien).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.SinhViens.Remove(db.SinhViens.Find(id));
            return db.SaveChanges();
        }
    }
}