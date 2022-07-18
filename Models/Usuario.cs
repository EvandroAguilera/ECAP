using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECAP.Models
{
    public class Usuario
    {
        public string dsSituacao { get; set; }
        public byte[] bnSenha { get; set; }
        public string dsLogin { get; set; }
    }
}