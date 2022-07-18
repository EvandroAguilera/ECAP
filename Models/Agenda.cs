using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECAP.Models
{
    public class Agenda
    {
        public int idAgenda { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Telefone { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Endereco { get; set; }
    }
}