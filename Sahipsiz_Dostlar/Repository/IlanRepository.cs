using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sahipsizler_Dostlar.Repository
{
    public class IlanRepository:IRepository<Ilanlar>
    {
        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();

        public void Add(Ilanlar entity)
        {
            try
            {
                if (db.Ilanlar.Where(x => x.HayvanId == entity.HayvanId) == null)
                {
                    db.Ilanlar.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Ilanlar entity)
        {
            try
            {
                if (db.Ilanlar.Where(x => x.HayvanId == entity.HayvanId) != null)
                {
                    db.Ilanlar.Remove(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ilanlar> GetAll()
        {
            return db.Ilanlar.ToList();
        }

        public Ilanlar GetById(int? id)
        {
            return db.Ilanlar.Find(id);
        }

        public void Update(Ilanlar entity)
        {
            try
            {
                if (db.Ilanlar.Where(x => x.HayvanId == entity.HayvanId) != null)
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