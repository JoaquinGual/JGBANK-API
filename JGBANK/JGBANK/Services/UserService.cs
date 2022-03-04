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
        public UserService(IAccountInterface accountInterface)
        {
                _accountInterface = accountInterface;
    }
        public async Task<string> EliminarUsuario(long dni)
        {



            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Usuario u = context.Usuarios.Where(u => u.Numdoc == dni).First();
                if (u != null)
                {
                    context.Remove(u);
                    respuesta = "Usuario eliminado con exito!";
                    context.SaveChanges();
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

                for (int i = 0; i < context.Usuarios.Count() ; i++)
                {
                    dtoUsuario du = new dtoUsuario();
                    du.nombre = LU[i].Nombre;
                    du.apellido = LU[i].Apellido;
                    du.numdoc = LU[i].Numdoc;
                    du.tipodoc = LU[i].Tipodoc;
                    du.fechaNac = LU[i].FechaNac;
                    du.idSexo = LU[i].IdSexo;
                    du.cuil = LU[i].Cuil;
                    du.email = LU[i].Email;
                    du.contrasenia = LU[i].Contrasenia;
                    LDU.Add(du);
                }
                return LDU;
                          
            }
        }

        public Task<List<Usuario>> GetUsuariosConCuentas(int numdoc)
        {
            using (var context = new JGBANKContext())
            {
                List<Usuario> LU = context.Usuarios.Where(x => x.Numdoc == numdoc).ToList();

                Usuario u = new Usuario();
                dtoUsuario du = new dtoUsuario();

                u = context.Usuarios.Where(d => d.Email == Email && d.Contrasenia == Contraseña).First();

                if (u != null)
                {
                    u.Token = token;
                    context.SaveChanges();
                }

                du.nombre = u.Nombre;
                du.apellido = u.Apellido;
                du.numdoc = u.Numdoc;
                du.tipodoc = u.Tipodoc;
                du.fechaNac = u.FechaNac;
                du.idSexo = u.IdSexo;
                du.cuil = u.Cuil;
                du.email = u.Email;
                du.contrasenia = u.Contrasenia;
                du.token = token;


                return du;
            }

        public async Task<dtoUsuario> LoginUser(string Email, string Contraseña)

        {
            string token = Guid.NewGuid().ToString();
             



            using (var context = new JGBANKContext())
            {
                Usuario u = new Usuario();
                dtoUsuario du = new dtoUsuario();

                u = context.Usuarios.Where(d => d.Email == Email && d.Contrasenia == Contraseña).First();

                if (u != null)
                {
                    u.Token = token;
                    context.SaveChanges();
                }

                du.nombre = u.Nombre;
                du.apellido = u.Apellido;
                du.numdoc = u.Numdoc;
                du.tipodoc = u.Tipodoc;
                du.fechaNac = u.FechaNac;
                du.idSexo = u.IdSexo;
                du.cuil = u.Cuil;
                du.email = u.Email;
                du.contrasenia = u.Contrasenia;
                du.token = token;

                
                return du;
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
               
                context.Usuarios.Add(u);
                context.SaveChanges();

                Usuario us = context.Usuarios.Where(x => x.Numdoc == u.Numdoc).First();

                dtoCuenta dc = new dtoCuenta();
                dc.idTipo = 0;
                dc.idUsuario = us.IdUsuario;
                dc.saldo = 0;
                dc.estado = true;
                await _accountInterface.crearCuenta(dc);
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

    }
}
