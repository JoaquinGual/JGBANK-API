using System;

namespace JGBANK.DTO
{
    public class dtoTarjeta
    {
        public int idTarjeta { get; set; }
        public string numTarjeta { get; set; }
        public int idTipo { get; set; }
        public string tipoTarjeta { get; set; }
        public DateTime fec_expedicion { get; set; }
        public DateTime fec_vencimiento { get; set; }
        public int ccv { get; set; }
        public bool estado { get; set; }
        public int idUsuario { get; set; }
    }
}
