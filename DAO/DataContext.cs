using ECAP.MAP;
using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECAP.DAO
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=SchoolContext") { }

        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AgendaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}