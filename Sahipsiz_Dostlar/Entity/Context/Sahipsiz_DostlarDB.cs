using Sahipsiz_Dostlar.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Context
{
    public class Sahipsiz_DostlarDB:DbContext
    {
        public Sahipsiz_DostlarDB():base("Sahipsiz_DostlarDB")
        {
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Ilanlar> Ilanlar { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Esbul> Esbul { get; set; }
    }
}