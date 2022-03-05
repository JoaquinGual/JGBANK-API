using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services
{

    public class CardService : ICardInterface
    {
       

        public async Task<dtoTarjeta> CrearTarjeta(int idTipo, bool estado, int idUsuario)
        {

            using (var context = new JGBANKContext())
            {
                Tarjeta t = new Tarjeta();

                Random r = new Random();
                t.NumTarjeta = Convert.ToString(r.Next(1000, 9999))+ Convert.ToString(r.Next(1000, 9999))+ Convert.ToString(r.Next(1000, 9999))+ Convert.ToString(r.Next(1000, 9999));
                t.IdTipo = idTipo;
                t.FecExpedicion = DateTime.Now;
                t.FecVencimiento = DateTime.Now.AddYears(3);
                t.Ccv = r.Next(100,999);
                t.Estado = estado;
                t.IdUsuario = idUsuario;

                context.Tarjetas.Add(t);
                context.SaveChanges();
                return MapTarjetaToDtoTarjeta(t);
            }

        }
        public async Task<string> SuspenderTarjeta(int idUsuario, string numTarjeta)
        {



            using (var context = new JGBANKContext())
            {
                string respuesta = "";
                Tarjeta t = context.Tarjetas.Where(u => u.IdUsuario == idUsuario && u.NumTarjeta == numTarjeta).First();
                if (t != null)
                {
                    t.Estado = false;
                    context.SaveChanges();
                    respuesta = "Tarjeta Suspendida con exito!";

                }
                else
                {
                    respuesta = "Tarjeta no encontrada!";
                }


                return respuesta;

            }
        }
        private dtoTarjeta MapTarjetaToDtoTarjeta(Tarjeta t)
        {
            TiposTarjeta TT = new TiposTarjeta();
            using (var context = new JGBANKContext())
            {
                TT = context.TiposTarjetas.Where(ta => ta.IdTipo == t.IdTipo).FirstOrDefault();

            }

            dtoTarjeta dt = new dtoTarjeta();
            dt.idTarjeta = t.IdTarjeta;
            dt.numTarjeta = t.NumTarjeta;
            dt.idTipo = t.IdTipo;
            dt.tipoTarjeta = TT.Tipo;
            dt.fec_expedicion = t.FecExpedicion;
            dt.fec_vencimiento = t.FecVencimiento;
            dt.ccv = t.Ccv;
            dt.estado = t.Estado;
            dt.idUsuario = t.IdUsuario;
            return dt;
        }
    }
}
