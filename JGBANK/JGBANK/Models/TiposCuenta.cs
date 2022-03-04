using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class TiposCuenta
    {
        public TiposCuenta()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int IdTipo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
