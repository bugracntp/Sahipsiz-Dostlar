using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Sahipsizler_Dostlar.Repository
{
    public class IlanRepository : IRepository<Ilanlar>
    {
        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();

        public void Add(Ilanlar entity)
        {
            try
            {
                db.Ilanlar.Add(entity);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Ilanlar entity, HttpPostedFileBase ImgURL)
        {
            try
            {
                if (ImgURL != null)
                {
                    WebImage img = new WebImage(ImgURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImgURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Ilanlar/" + logoname);

                    entity.ImgURL = "/Uploads/Ilanlar/" + logoname;
                }
                db.Ilanlar.Add(entity);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
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

        public void Update(Ilanlar entity, HttpPostedFileBase ImgURL)
        {
            try
            {
                if (db.Ilanlar.Where(x => x.HayvanId == entity.HayvanId) != null)
                {
                    if (ImgURL != null)
                    {
                        WebImage img = new WebImage(ImgURL.InputStream);
                        FileInfo imginfo = new FileInfo(ImgURL.FileName);

                        string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                        img.Resize(500, 500);
                        img.Save("~/Uploads/Ilanlar/" + logoname);

                        entity.ImgURL = "/Uploads/Ilanlar/" + logoname;
                    }
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Add(entity, ImgURL);
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
    }
}