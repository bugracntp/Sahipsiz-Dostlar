using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sahipsiz_Dostlar.Repository
{
    public class KullaniciRepository : IRepository<Kullanici>
    {
        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();

        public void Add(Kullanici entity)
        {
            try
            {
                db.Kullanici.Add(entity);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Kullanici> GetAll()
        {
            return db.Kullanici.ToList();
        }

        public Kullanici GetById(int? id)
        {
            return db.Kullanici.Find(id);
        }

        public void Update(Kullanici entity)
        {
            try
            {
                if (db.Kullanici.Where(x => x.KullaniciID == entity.KullaniciID) != null)
                {
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsEmailExist(string email)
        {
            using (Sahipsiz_DostlarDB dc = new Sahipsiz_DostlarDB())
            {
                var v = dc.Kullanici.Where(a => a.Email == email).FirstOrDefault();
                return v != null;
            }
        }
    }
}