using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JGBANK.Services
{
    public class AccountService : IAccountInterface
    {
        public async Task<Cuenta> crearCuenta(dtoCuenta acc)
        {

            using (var context = new JGBANKContext())
            {
                Cuenta c = new Cuenta();
                Random r = new Random();
                c.NumCuenta = Convert.ToString(r.Next(10000, 99999));
                c.IdTipo = acc.idTipo;
                c.IdUsuario = acc.idUsuario;
                c.Saldo = acc.saldo;
                c.Estado = acc.estado;

                context.Cuentas.Add(c);
                context.SaveChanges();
                return c;
            }


        }

        public async Task<string> EliminarCuenta(string numeroCuenta)
        {

            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Cuenta c = context.Cuentas.Where(u => u.NumCuenta == numeroCuenta).First();
                if (c != null)
                {
                    c.Estado = false;
                    context.SaveChanges();
                    respuesta = "Cuenta eliminada con exito!";
                    
                }
                else
                {
                    respuesta = "Cuenta no encontrada!";
                }


                return respuesta;

            }

        }
    }
}
