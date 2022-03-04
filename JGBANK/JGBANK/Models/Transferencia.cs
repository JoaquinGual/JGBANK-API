using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Transferencia
    {
        public int IdTransferencia { get; set; }
        public double Monto { get; set; }
        public DateTime FechaTrans { get; set; }
        public int IdCuentaSalida { get; set; }
        public int IdCuentaDestino { get; set; }

        public virtual Cuenta IdCuentaDestinoNavigation { get; set; }
        public virtual Cuenta IdCuentaSalidaNavigation { get; set; }
    }
}
