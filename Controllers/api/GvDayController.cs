using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiTH5.Models;

namespace BaiTH5.Controllers.api
{
    public class GvDayController:ApiController
    {
        private DBContext db = new DBContext();
        public IQueryable<Gv_day> Get()
        {
            return db.Gv_day;
        }

        public Gv_day Get(int idgv,int idmh)
        {
            return db.Gv_day.FirstOrDefault(x => x.Magv == idgv && x.Mamh == idmh);
        }

        public int Post([FromBody] Gv_day gvDay)
        {
            db.Gv_day.Add(gvDay);
            return db.SaveChanges();
        }

        public int Put([FromBody] Gv_day gvDay)
        {
            db.Gv_day.Add(gvDay);
            db.Entry(gvDay).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int idgv, int idmh)
        {
            db.Gv_day.Remove(db.Gv_day.FirstOrDefault(x => x.Magv == idgv && x.Mamh == idmh));
            return db.SaveChanges();
        }
    }
}