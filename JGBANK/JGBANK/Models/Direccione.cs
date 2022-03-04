using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Direccione
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
