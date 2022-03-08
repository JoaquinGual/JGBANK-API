using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.DTO
{
    public class dtoTransferencia
    {
        public int idTransferencia { get; set; }
        public double monto { get; set; }
        public DateTime fechaTrans { get; set; }
        public int idCuentaSalida { get; set; }
        public string numeroCuentaSalida { get; set; }

        public string nombreCuentaSalida { get; set; }
        public int idCuentaDestino { get; set; }
        public string numeroCuentaDestino { get; set; }
        public string nombreCuentaDestino { get; set; }
    }
}
