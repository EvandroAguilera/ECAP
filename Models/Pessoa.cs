using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECAP.Models
{
    public class Pessoa
    {
        public int? idPessoa { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string Nome { get; set; }
        public string Salario { get; set; }

        public int? idDepartamento { get; set; }

        public Departamento Departamento { get; set; }

        //public Pessoa() 
        //{
        //    this.Departamento = new Departamento();
        //}
    }
}