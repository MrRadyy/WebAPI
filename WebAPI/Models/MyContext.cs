using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        
        public DbSet<Backup> Backup { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Sources> Sources { get; set;}
        public DbSet<Network_Logins> Networks { get; set; }
        public DbSet<Computers> Computers { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<FTP_Logins> FTP_Logins { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Local> Local { get; set; }
      


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}