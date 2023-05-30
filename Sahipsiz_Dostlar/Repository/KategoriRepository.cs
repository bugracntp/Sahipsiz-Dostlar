using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Repository
{
    public class KategoriRepository : IRepository<Kategori>
    {

        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();

        public void Add(Kategori entity)
        {
            try
            {
                if (db.Kategori.Where(x => x.KategoriID == entity.KategoriID) == null)
                {
                    db.Kategori.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Kategori entity)
        {
            try
            {
                if (db.Kategori.Where(x => x.KategoriID == entity.KategoriID) != null)
                {
                    db.Kategori.Remove(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Kategori> GetAll()
        {
            return db.Kategori.ToList();
        }

        public Kategori GetById(int? id)
        {
            return db.Kategori.Find(id);
        }

        public void Update(Kategori entity)
        {
            try
            {
                if (db.Kategori.Where(x => x.KategoriID == entity.KategoriID) != null)
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
    }
}