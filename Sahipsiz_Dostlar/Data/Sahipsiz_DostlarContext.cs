using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Data
{
    public class Sahipsiz_DostlarContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Sahipsiz_DostlarContext() : base("name=Sahipsiz_DostlarContext")
        {
        }

        public System.Data.Entity.DbSet<Sahipsiz_Dostlar.Entity.Models.Kategori> Kategoris { get; set; }

        public System.Data.Entity.DbSet<Sahipsiz_Dostlar.Entity.Models.Kullanici> Kullanicis { get; set; }

        public System.Data.Entity.DbSet<Sahipsiz_Dostlar.Entity.Models.Esbul> Esbuls { get; set; }

        public System.Data.Entity.DbSet<Sahipsiz_Dostlar.Entity.Models.Sehir> Sehirs { get; set; }
    }
}
