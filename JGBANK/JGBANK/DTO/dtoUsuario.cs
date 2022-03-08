using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.DTO
{
    public class dtoUsuario
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int numdoc { get; set; }
        public int tipodoc { get; set; }
        public DateTime fechaNac { get; set; }
        public int idSexo { get; set; }
        public string sexo { get; set; }
        public long cuil { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }

        public List<dtoTelefono> LT { get; set; }

        public List<dtoDireccion> LD { get; set; }

        public bool estado { get; set; }
        public string token { get; set; }

    }
}
