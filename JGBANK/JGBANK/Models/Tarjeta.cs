using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public string NumTarjeta { get; set; }
        public int IdTipo { get; set; }
        public DateTime FecExpedicion { get; set; }
        public DateTime FecVencimiento { get; set; }
        public int Ccv { get; set; }
        public bool Estado { get; set; }
        public int IdUsuario { get; set; }

        public virtual TiposTarjeta IdTipoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
