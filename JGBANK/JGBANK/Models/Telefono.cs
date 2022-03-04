using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Telefono
    {
        public int IdTelefono { get; set; }
        public int IdUsuario { get; set; }
        public string NumTel { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
