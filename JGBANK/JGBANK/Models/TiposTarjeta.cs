using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class TiposTarjeta
    {
        public TiposTarjeta()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int IdTipo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
