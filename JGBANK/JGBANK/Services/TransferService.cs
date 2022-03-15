using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services
{
    public class TransferService : ITransferInterface
    {
        public async Task<double> getSaldo(int idCuenta)
        {
            await using (var context = new JGBANKContext())
            {
                Cuenta c = context.Cuentas.Where(c => c.IdCuenta == idCuenta).FirstOrDefault();
                return c.Saldo;
            }
        }

        public async Task<List<dtoTransferencia>> GetTransferenciasRealizadas(int idCuenta)
        {
            using (var context = new JGBANKContext())
            {
                List<Transferencia> LTR = context.Transferencias.Where(u => u.IdCuentaSalida == idCuenta).ToList();
                List<dtoTransferencia> LDTR = new List<dtoTransferencia>();

                foreach (var tr in LTR)
                {

                    LDTR.Add(MapToDtoTransferencia(tr));
                }
                return LDTR;
            }
        }

        public async Task<List<dtoTransferencia>> GetTransferenciasRecibidas(int idCuenta)
        {
            using (var context = new JGBANKContext())
            {
                List<Transferencia> LTR = context.Transferencias.Where(u => u.IdCuentaDestino == idCuenta).ToList();
                List<dtoTransferencia> LDTR = new List<dtoTransferencia>();

                foreach (var tr in LTR)
                {

                    LDTR.Add(MapToDtoTransferencia(tr));
                }
                return LDTR;
            }
        }

        public async Task<dtoTransferencia> RealizarTransferencia(double monto, int idCuentaSalida, int idCuentaDestino)
        {
            using (var context = new JGBANKContext())
            {
                Transferencia t = new Transferencia();
                t.Monto = monto;
                t.FechaTrans = DateTime.Now;
                t.IdCuentaSalida = idCuentaSalida;
                t.IdCuentaDestino = idCuentaDestino;

                Cuenta cs = context.Cuentas.Where(c => c.IdCuenta == idCuentaSalida).FirstOrDefault();
                cs.Saldo = cs.Saldo - monto;
                Cuenta cd = context.Cuentas.Where(cd => cd.IdCuenta == idCuentaDestino).FirstOrDefault();
                cd.Saldo = cd.Saldo + monto;
                context.Transferencias.Add(t);
                context.SaveChanges();
                return MapToDtoTransferencia(t);
            }

                
        }



        private dtoTransferencia MapToDtoTransferencia(Transferencia t)
        {
            using (var context = new JGBANKContext())
            {
                dtoTransferencia dt = new dtoTransferencia();
                //Traigo relaciones para llenar el DTO con datos correspondientes
                Cuenta cs = context.Cuentas.Where(cs => cs.IdCuenta == t.IdCuentaSalida).FirstOrDefault();
                Cuenta cd = context.Cuentas.Where(cd => cd.IdCuenta == t.IdCuentaDestino).FirstOrDefault();
                Usuario us = context.Usuarios.Where(us => us.IdUsuario == cs.IdUsuario).FirstOrDefault();
                Usuario ud = context.Usuarios.Where(ud => ud.IdUsuario == cd.IdUsuario).FirstOrDefault();
                dt.idTransferencia = t.IdTransferencia;
                dt.monto = t.Monto;
                dt.fechaTrans = t.FechaTrans;
                dt.idCuentaSalida = t.IdCuentaSalida;             
                dt.numeroCuentaSalida = cs.NumCuenta;
                dt.nombreCuentaSalida = us.Apellido + "," + us.Nombre;
                dt.idCuentaDestino = t.IdCuentaDestino;
                dt.numeroCuentaDestino = cd.NumCuenta;
                dt.nombreCuentaDestino = ud.Apellido + "," + ud.Nombre;

                return dt;

            }
               
        }
    }
}
