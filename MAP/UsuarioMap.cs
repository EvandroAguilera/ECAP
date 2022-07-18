using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;


namespace ECAP.MAP
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap() 
        {
            this.ToTable("tabUsuario");
            this.HasKey(x => x.dsLogin);

            this.Property(x => x.dsLogin).HasColumnName("dsLogin");
            this.Property(x => x.dsSituacao).HasColumnName("dsSituacao");
            this.Property(x => x.bnSenha).HasColumnName("bnSenha");
        }
    }
}