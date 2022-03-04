using System;
using System.Collections.Generic;

#nullable disable

namespace JGBANK.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cuenta = new HashSet<Cuenta>();
            Direcciones = new HashSet<Direccione>();
            Tarjeta = new HashSet<Tarjeta>();
            Telefonos = new HashSet<Telefono>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Numdoc { get; set; }
        public int Tipodoc { get; set; }
        public DateTime FechaNac { get; set; }
        public int IdSexo { get; set; }
        public byte[] FotoPerfil { get; set; }
        public long Cuil { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Token { get; set; }

        public virtual Sexo IdSexoNavigation { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
        public virtual ICollection<Direccione> Direcciones { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
