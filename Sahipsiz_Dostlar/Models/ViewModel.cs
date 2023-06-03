using Sahipsiz_Dostlar.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Models
{
    public class ViewModel
    {
        public List<Ilanlar> Ilanlar { get; set; }
        public List<Kategori> Kategori { get; set; }
        public List<Esbul> Esbul { get; set; }
    }
}