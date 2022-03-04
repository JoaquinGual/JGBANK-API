using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class ComprasDolare
    {
        public int IdCompra { get; set; }
        public double MontoPesos { get; set; }
        public double MontoDolar { get; set; }
        public DateTime FechaCompra { get; set; }
        public double ValorDolar { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
    }
}
