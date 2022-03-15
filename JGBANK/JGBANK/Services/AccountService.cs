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
        public async Task<dtoCuenta> crearCuenta(int idTipo, int idUsuario, double saldo, bool estado)
        {

            using (var context = new JGBANKContext())
            {
                Cuenta c = new Cuenta();
                Random r = new Random();
                c.NumCuenta = Convert.ToString(r.Next(10000, 99999));
                c.IdTipo = idTipo;
                c.IdUsuario = idUsuario;
                c.Saldo = saldo;
                c.Estado = estado;
                

                context.Cuentas.Add(c);
                context.SaveChanges();
                return MapCuentaToDtoCuenta(c);
            }


        }

        public async Task<string> EliminarCuenta(int idUsuario,string numeroCuenta)
        {
            
            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Cuenta c = context.Cuentas.Where(c => c.NumCuenta == numeroCuenta && c.IdUsuario == idUsuario).First();
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

        public async Task<dtoCuenta> getCuentaByNumCuenta(string numCuenta)
        {
            await using (var context = new JGBANKContext())
            {
                Cuenta c = context.Cuentas.Where(x => x.NumCuenta == numCuenta).First();
                return MapCuentaToDtoCuenta(c);
            }
                
        }

        private dtoCuenta MapCuentaToDtoCuenta(Cuenta c)
        {
            TiposCuenta TC = new TiposCuenta();
            Usuario u = new Usuario(); 
            using (var context = new JGBANKContext())
            {
                TC = context.TiposCuentas.Where(t => t.IdTipo == c.IdTipo).FirstOrDefault();
                u = context.Usuarios.Where(u => u.IdUsuario == c.IdUsuario).First();

            }
            dtoCuenta dc = new dtoCuenta();
            dc.idCuenta = c.IdCuenta;
            dc.numCuenta = c.NumCuenta;
            dc.idTipo = c.IdTipo;
            dc.tipoCuenta = TC.Tipo;
            dc.idUsuario = c.IdUsuario;
            dc.saldo = c.Saldo;
            dc.estado =dc.estado;
            dc.nombreCompleto = u.Nombre + " " + u.Apellido;
           
            return dc;
        }

        public bool getEstadoCuenta(int idCuenta)
        {
            using (var context = new JGBANKContext())
            {
                Cuenta c = context.Cuentas.Where(c => c.IdCuenta == idCuenta).First();
                return c.Estado;
            }
        }

        public async Task<List<dtoCuenta>> getCuentasActivas()
        {
            using (var context = new JGBANKContext())
            {
                List<Cuenta> LC = context.Cuentas.Where(c => c.Estado == true).ToList();
                List<dtoCuenta> LDC = new List<dtoCuenta>();

                foreach (var c in LC)
                {
                    
                    LDC.Add(MapCuentaToDtoCuenta(c));
                }
                return LDC;

            }
        }
    }
}
