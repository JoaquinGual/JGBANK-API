using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services
{
    public class AddressService : IAddressInterface
    {
        public async Task<List<dtoDireccion>> GetDirecciones(int idUsuario)
        {
            await using (var context = new JGBANKContext())
            {
                List<Direccione> LD = context.Direcciones.Where(d => d.IdUsuario == idUsuario).ToList();
                return  MapListDireccioneToListDtoDireccion(LD);
            }
        }

      
        private List<dtoDireccion> MapListDireccioneToListDtoDireccion(List<Direccione> LD)
        {
            List<dtoDireccion> LDD = new List<dtoDireccion>();
            for (int i = 0; i < LD.Count(); i++)
            {
                dtoDireccion dd = new dtoDireccion();
                dd.idDireccion = LD[i].IdDireccion;
                dd.idUsuario = LD[i].IdUsuario;
                dd.calle = LD[i].Calle;
                dd.numero = LD[i].Numero;
                LDD.Add(dd);
            }
           
            return LDD;
        }
    }
}
