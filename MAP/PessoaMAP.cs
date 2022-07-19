using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ECAP.MAP
{
    public class PessoaMAP : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMAP()
        {
            this.ToTable("tabPessoa");
            this.HasKey(x => x.idPessoa);

            this.Property(x => x.idPessoa).HasColumnName("idPessoa");
            this.Property(x => x.Nome).HasColumnName("Nome");
            this.Property(x => x.Salario).HasColumnName("Salario");
            this.Property(x => x.idDepartamento).HasColumnName("idDepartamento");

            this.HasOptional(t => t.Departamento)
               .WithMany(t => t.Pessoas)
               .HasForeignKey(d => d.idDepartamento);
        }
    }
}