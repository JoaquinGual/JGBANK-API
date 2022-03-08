using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.DTO
{
    public class dtoDireccion
    {
        public int idDireccion { get; set; }
        public int idUsuario { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
    }
}
