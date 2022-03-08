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
        private readonly IAddressInterface _addressInterface;
        private readonly IPhoneInterface _phoneInterface;
        public UserService(IAccountInterface accountInterface, ICardInterface cardInterface, IAddressInterface addressInterface, IPhoneInterface phoneInterface)
        {
            _accountInterface = accountInterface;
            _cardInterface = cardInterface;
              _addressInterface = addressInterface;
            _phoneInterface = phoneInterface;
    }
        public async Task<string> EliminarUsuario(long dni)
        {

            //Cuando se elimina un usuario por defecto se dan de baja todas sus tarjetas y su cuentas vigentes
            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Usuario u = context.Usuarios.Where(u => u.Numdoc == dni).First();
                List<Tarjeta> LT = context.Tarjetas.Where(t => t.IdUsuario == u.IdUsuario).ToList();
                List<Cuenta> LC = context.Cuentas.Where(c => c.IdUsuario == u.IdUsuario).ToList();
                if (u != null)
                {
                    u.Estado = false;
                    for (int i = 0; i < LT.Count(); i++)
                    {
                       await _cardInterface.SuspenderTarjeta(u.IdUsuario, LT[i].NumTarjeta);
                        
                    }
                    for (int i = 0; i < LC.Count(); i++)
                    {
                        await _accountInterface.EliminarCuenta(u.IdUsuario, LC[i].NumCuenta);
                    }
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

                    LDU.Add(await MapUsuarioToDtoUsuario(LU[i]));
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




                return await MapUsuarioToDtoUsuario(u);
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
        public async Task<Usuario> cargarFoto(int idUsuario, byte[] foto)
        {
            using (var context = new JGBANKContext())
            {
                Usuario u = context.Usuarios.Where(x => x.IdUsuario == idUsuario).First();
                u.FotoPerfil = foto;
                context.SaveChanges();
                return u;
            }
        }
        public async Task<Usuario> getUserByID(int idUsuario)
        {
            using (var context = new JGBANKContext())
            {
                Usuario u = context.Usuarios.Where(x => x.IdUsuario == idUsuario).First();                
                return u;
            }
        }
        public async Task<Usuario> RegistrarUsuario(dtoUsuario user/*, List<Telefono> LT, List<Direccione> LD*/)
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


                //Filtra por nrodoc, Usuario Creado arriba
                context.Usuarios.Add(u);
                context.SaveChanges();
                Usuario us = context.Usuarios.Where(x => x.Numdoc == u.Numdoc).First();
                

                //Registrar Telefonos

                List<Telefono> LT =  _phoneInterface.MapListDtoTelefonoToListTelefono(user.LT,us.IdUsuario);

                for (int i = 0; i < LT.Count(); i++)
                {
                    context.Telefonos.Add(LT[i]);
                }


                //Registar Direciones
                List<Direccione> LD = _addressInterface.MapListDtoDireccionToListDireccion(user.LD,us.IdUsuario);
                for (int i = 0; i < user.LD.Count(); i++)
                {
                    context.Direcciones.Add(LD[i]);
                }
                context.SaveChanges();



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
        private async Task<dtoUsuario> MapUsuarioToDtoUsuario(Usuario u)
        {
           using (var context = new JGBANKContext())
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
                du.LT = await _phoneInterface.GetTelefonos(u.IdUsuario);
                du.LD = await _addressInterface.GetDirecciones(u.IdUsuario);
                du.estado = u.Estado;
                du.token = u.Token;

                return du;
            }
        }
        
        public bool GetEstadoUsuario(int idUsuario)
        {
            using (var context = new JGBANKContext())
            {
                Usuario u = context.Usuarios.Where(u => u.IdUsuario == idUsuario).First();
                return u.Estado;
            }
                
        }
    }
}
