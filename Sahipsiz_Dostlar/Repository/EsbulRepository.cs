using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Sahipsiz_Dostlar.Repository
{
    public class EsbulRepository : IRepository<Esbul>
    {
        private readonly Sahipsiz_DostlarDB DB = new Sahipsiz_DostlarDB();
        public void Add(Esbul entity)
        {
            try
            {
                DB.Esbul.Add(entity);
                DB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Esbul entity, HttpPostedFileBase ImgURL)
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
                DB.Esbul.Add(entity);
                DB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Esbul> GetAll()
        {
            return DB.Esbul.ToList();
        }

        public Esbul GetById(int? id)
        {
            return DB.Esbul.Find(id);
        }

        public void Update(Esbul entity)
        {
            try
            {
                if (DB.Esbul.Where(x => x.HayvanId == entity.HayvanId) != null)
                {
                    DB.Entry(entity).State = EntityState.Modified;
                    DB.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Esbul entity, HttpPostedFileBase ImgURL)
        {
            try
            {
                if (DB.Esbul.Where(x => x.HayvanId == entity.HayvanId) != null)
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
                    DB.Entry(entity).State = EntityState.Modified;
                    DB.SaveChanges();
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
    }
}