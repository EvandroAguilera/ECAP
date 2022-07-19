using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECAP.Models
{
    public class Departamento
    {
        public int idDepartamento { get; set; }

        [StringLength(150, MinimumLength = 2)]
        public string Nome { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }

    }
}