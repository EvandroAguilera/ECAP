using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ECAP.MAP
{
    public class DepartamentoMap : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMap()
        {
            this.ToTable("tabDepartamento");
            this.HasKey(x => x.idDepartamento);

            this.Property(x => x.idDepartamento).HasColumnName("idDepartamento");
            this.Property(x => x.Nome).HasColumnName("Nome");
        }
    }
}