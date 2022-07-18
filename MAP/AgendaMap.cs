using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ECAP.MAP
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {
            this.ToTable("tabAgenda");
            this.HasKey(x => x.idAgenda);

            this.Property(x => x.idAgenda).HasColumnName("idAgenda");
            this.Property(x => x.Nome).HasColumnName("Nome");
            this.Property(x => x.Telefone).HasColumnName("Telefone");
            this.Property(x => x.Endereco).HasColumnName("Endereco");
        }
    }
}