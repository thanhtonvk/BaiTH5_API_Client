using BaiTH5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH5.Controllers.api
{
    public class BangDiemController : ApiController
    {
        DBContext db = new DBContext();
        public int PostBangDiem([FromBody] Bangdiem bangDiem)
        {
            db.Bangdiems.Add(bangDiem);
            return db.SaveChanges();
        }
        public int PutBangDiem([FromBody] Bangdiem bangDiem)
        {
            db.Bangdiems.Add(bangDiem);
            db.Entry(bangDiem).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int DeleteBangDiem(int idsv, int idmh)
        {
            db.Bangdiems.Remove(db.Bangdiems.FirstOrDefault(x => x.Mamh == idmh && x.Masv == idsv));
            return db.SaveChanges();
        }
        public IQueryable<Bangdiem> GetBangdiems()
        {
            return db.Bangdiems;
        }
        public Bangdiem GetBangdiems(int idsv, int idmh)
        {
            return db.Bangdiems.FirstOrDefault(x => x.Masv == idsv && x.Mamh == idmh);
        }


    }
}
