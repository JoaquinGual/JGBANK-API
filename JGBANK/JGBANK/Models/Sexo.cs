using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Sexo
    {
        public Sexo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdSexo { get; set; }
        public string Sexo1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
