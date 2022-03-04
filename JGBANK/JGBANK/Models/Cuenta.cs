using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            ComprasDolares = new HashSet<ComprasDolare>();
            Depositos = new HashSet<Deposito>();
            TransferenciaIdCuentaDestinoNavigations = new HashSet<Transferencia>();
            TransferenciaIdCuentaSalidaNavigations = new HashSet<Transferencia>();
            VentaDolares = new HashSet<VentaDolare>();
        }

        public int IdCuenta { get; set; }
        public string NumCuenta { get; set; }
        public int IdTipo { get; set; }
        public int IdUsuario { get; set; }
        public double Saldo { get; set; }
        public bool Estado { get; set; }

        public virtual TiposCuenta IdTipoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ComprasDolare> ComprasDolares { get; set; }
        public virtual ICollection<Deposito> Depositos { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdCuentaDestinoNavigations { get; set; }
        public virtual ICollection<Transferencia> TransferenciaIdCuentaSalidaNavigations { get; set; }
        public virtual ICollection<VentaDolare> VentaDolares { get; set; }
    }
}
