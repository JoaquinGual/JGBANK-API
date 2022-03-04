using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.DTO
{
    public class dtoCuenta
    {
        public int idCuenta { get; set; }

        public string numCuenta { get; set; }
        public int idTipo { get; set; }
        public int idUsuario { get; set; }
        public double saldo { get; set; }
        public bool estado { get; set; }
    }
}
