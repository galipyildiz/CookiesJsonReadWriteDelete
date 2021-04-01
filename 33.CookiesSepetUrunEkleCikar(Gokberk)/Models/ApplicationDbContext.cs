using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _33.CookiesSepetUrunEkleCikar_Gokberk_.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=Baglantim")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}