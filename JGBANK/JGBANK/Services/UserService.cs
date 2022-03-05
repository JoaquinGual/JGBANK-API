using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services
{
    public class UserService : IUserInterface
    {

        private readonly IAccountInterface _accountInterface;
        private readonly ICardInterface _cardInterface;
        public UserService(IAccountInterface accountInterface, ICardInterface cardInterface)
        {
            _accountInterface = accountInterface;
            _cardInterface = cardInterface;
        }
        public async Task<string> EliminarUsuario(long dni)
        {



            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Usuario u = context.Usuarios.Where(u => u.Numdoc == dni).First();
                if (u != null)
                {
                    u.Estado = false;
                    context.SaveChanges();
                    respuesta = "Usuario eliminado con exito!";
                    
                }
                else
                {
                    respuesta = "Usuario no encontrado!";
                }


                return respuesta;

            }
        }

        public async Task<List<dtoUsuario>> GetUsuarios()
        {
            using (var context = new JGBANKContext())
            {

                List<dtoUsuario> LDU = new List<dtoUsuario>();
                List<Usuario> LU = context.Usuarios.ToList();

                for (int i = 0; i < context.Usuarios.Count(); i++)
                {

                    LDU.Add(MapUsuarioToDtoUsuario(LU[i]));
                }
                return LDU;

            }
        }

        public async Task<dtoUsuarioCuentaTarjeta> GetUsuariosConCuentasTarjetas(int numdoc)
        {
            using (var context = new JGBANKContext())
            {
                //Llamo Usuario por DNI
                Usuario u = context.Usuarios.Where(x => x.Numdoc == numdoc).First();

                //Busco cuentas y tarjetas a su nombre
                List<Cuenta> LC = context.Cuentas.Where(x => x.IdUsuario == u.IdUsuario).ToList();
                List<Tarjeta> LT = context.Tarjetas.Where(x => x.IdUsuario == u.IdUsuario).ToList();

                //Mapeo para mostrar datos de las mismas
                List<dtoCuenta> LDC = MapListCuentaToListDtoCuenta(LC);
                List<dtoTarjeta> LDT = MapListTarjetaToListDtoTarjeta(LT);

                //Mapeo para devolver Json de forma correcta
                dtoUsuarioCuentaTarjeta uct = MapToDtoUsuarioCuentaTarjeta(u, LDC, LDT);

                return uct;
            }
        }

        public async Task<dtoUsuario> LoginUser(string Email, string Contraseña)

        {
            string token = Guid.NewGuid().ToString();




            using (var context = new JGBANKContext())
            {
                Usuario u = new Usuario();
                dtoUsuario du = new dtoUsuario();

                u = context.Usuarios.Where(d => d.Email == Email && d.Contrasenia == Contraseña && d.Estado == true).First();

                if (u != null)
                {
                    u.Token = token;
                    context.SaveChanges();
                }




                return MapUsuarioToDtoUsuario(u);
            }
        }

        public async Task<Usuario> ModificarUsuario(dtoUsuario user)
        {
            using (var context = new JGBANKContext())
            {
                Usuario u = new Usuario();


                u = context.Usuarios.Where(d => d.Email == user.email).First();
                if (user.nombre != "")
                {
                    u.Nombre = user.nombre;
                }
                if (user.apellido != "")
                {
                    u.Apellido = user.apellido;
                }
                if (user.numdoc != 0)
                {
                    u.Numdoc = user.numdoc;
                }
                if (user.tipodoc != -1)
                {
                    u.Tipodoc = user.tipodoc;
                }
                if (user.fechaNac.ToShortDateString() != DateTime.Today.ToShortDateString())
                {
                    u.FechaNac = user.fechaNac;
                }
                if (user.idSexo != u.IdSexo)
                {
                    u.IdSexo = user.idSexo;
                }
                if (user.cuil != 0)
                {
                    u.Cuil = user.cuil;
                }
                if (user.email != "")
                {
                    u.Email = user.email;
                }
                if (user.contrasenia != "")
                {
                    u.Contrasenia = user.contrasenia;
                }




                context.SaveChanges();
                return u;
            }
        }

        public async Task<Usuario> RegistrarUsuario(dtoUsuario user)
        {
            await using (var context = new JGBANKContext())
            {
                //Crea Usuario
                Usuario u = new Usuario();
                u.Nombre = user.nombre;
                u.Apellido = user.apellido;
                u.Numdoc = user.numdoc;
                u.Tipodoc = user.tipodoc;
                u.FechaNac = user.fechaNac;
                u.IdSexo = user.idSexo;
                u.Cuil = user.cuil;
                u.Email = user.email;
                u.Contrasenia = user.contrasenia;
                u.Estado = true;
                context.Usuarios.Add(u);
                context.SaveChanges();

                //Filtra por nrodoc, Usuario Creado arriba
                Usuario us = context.Usuarios.Where(x => x.Numdoc == u.Numdoc).First();

                //Crea cuenta en pesos para ese Usuario
                dtoCuenta dc = new dtoCuenta();
                dc.idTipo = 0;
                dc.idUsuario = us.IdUsuario;
                dc.saldo = 0;
                dc.estado = true;
                await _accountInterface.crearCuenta(dc.idTipo,dc.idUsuario,dc.saldo,dc.estado);

                //Crea Tarjeta de Debito para ese Usuario
                dtoTarjeta dt = new dtoTarjeta();
                dt.idUsuario = us.IdUsuario;
                dt.estado = true;
                dt.idTipo = 0;
                await _cardInterface.CrearTarjeta(dt.idTipo,dt.estado,dt.idUsuario);

                //Retorna el Usuario Completo
                return u;
            }

        }

        public bool VerificarToken(string token)
        {
            List<Usuario> LU = new List<Usuario>();
            using (var context = new JGBANKContext())
            {
                LU = context.Usuarios.Where(x => x.Token == token).ToList();

            }

            if (LU.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private dtoUsuarioCuentaTarjeta MapToDtoUsuarioCuentaTarjeta(Usuario u, List<dtoCuenta> LC, List<dtoTarjeta> LT)
        {
            dtoUsuarioCuentaTarjeta uct = new dtoUsuarioCuentaTarjeta();

            uct.nombre = u.Nombre;
            uct.apellido = u.Apellido;
            uct.numdoc = u.Numdoc;
            uct.tipodoc = u.Tipodoc;
            uct.fechaNac = u.FechaNac;
            uct.idSexo = u.IdSexo;
            uct.cuil = u.Cuil;
            uct.email = u.Email;
            uct.contrasenia = u.Contrasenia;
            uct.token = u.Token;
            uct.Cuentas = LC;
            uct.Tarjetas = LT;
            return uct;

        }
        private List<dtoCuenta> MapListCuentaToListDtoCuenta(List<Cuenta> LC)
        {

            List<dtoCuenta> LDC = new List<dtoCuenta>();
            for (int i = 0; i < LC.Count(); i++)
            {
                TiposCuenta TC = new TiposCuenta();
                using (var context = new JGBANKContext())
                {
                    TC = context.TiposCuentas.Where(t => t.IdTipo == LC[i].IdTipo).FirstOrDefault();

                }
                dtoCuenta dc = new dtoCuenta();

                dc.idCuenta = LC[i].IdCuenta;
                dc.numCuenta = LC[i].NumCuenta;
                dc.idTipo = LC[i].IdTipo;             
                dc.tipoCuenta = TC.Tipo;
                dc.idUsuario = LC[i].IdUsuario;
                dc.saldo = LC[i].Saldo;
                dc.estado = LC[i].Estado;
                LDC.Add(dc);
            }


            return LDC;


        }
        private List<dtoTarjeta> MapListTarjetaToListDtoTarjeta(List<Tarjeta> LT)
        {
            List<dtoTarjeta> LDT = new List<dtoTarjeta>();
            for (int i = 0; i < LT.Count(); i++)
            {
                TiposTarjeta TT = new TiposTarjeta();
                using (var context = new JGBANKContext())
                {
                    TT = context.TiposTarjetas.Where(t => t.IdTipo == LT[i].IdTipo).FirstOrDefault();

                }
                dtoTarjeta dt = new dtoTarjeta();

                dt.idTarjeta = LT[i].IdTarjeta;
                dt.numTarjeta = LT[i].NumTarjeta;
                dt.idTipo = LT[i].IdTipo;
                dt.tipoTarjeta = TT.Tipo;
                dt.fec_expedicion = LT[i].FecExpedicion;
                dt.fec_vencimiento = LT[i].FecVencimiento;
                dt.ccv = LT[i].Ccv;
                dt.estado = LT[i].Estado;
                dt.idUsuario = LT[i].IdUsuario;
                LDT.Add(dt);
            }

            return LDT;


        }
        private dtoUsuario MapUsuarioToDtoUsuario(Usuario u)
        {
            dtoUsuario du = new dtoUsuario();
            du.nombre = u.Nombre;
            du.apellido = u.Apellido;
            du.numdoc = u.Numdoc;
            du.tipodoc = u.Tipodoc;
            du.fechaNac = u.FechaNac;
            du.idSexo = u.IdSexo;
            du.cuil = u.Cuil;
            du.email = u.Email;
            du.contrasenia = u.Contrasenia;
            du.estado = u.Estado;
            du.token = u.Token;
            return du;
        }
    }
}
