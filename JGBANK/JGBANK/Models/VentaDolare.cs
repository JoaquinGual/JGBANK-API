using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class VentaDolare
    {
        public int IdVenta { get; set; }
        public double MontoDolar { get; set; }
        public double MontoPesos { get; set; }
        public DateTime FechaVenta { get; set; }
        public double ValorDolar { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
    }
}
