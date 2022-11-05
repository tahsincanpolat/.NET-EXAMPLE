using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OgrenciBilgiSistemi.DAL
{
    public class OBSContext : DbContext
    {
        public OBSContext() : base("OBSVeritabani") { }

        public DbSet<Fakulte> Fakulteler { get; set; }

        // s takısını kaldırmak için
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}