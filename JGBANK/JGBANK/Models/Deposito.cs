using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Deposito
    {
        public int IdDeposito { get; set; }
        public double MontoDeposito { get; set; }
        public DateTime FechaDeposito { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; }
    }
}
