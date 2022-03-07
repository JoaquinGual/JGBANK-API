using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services
{
    public class PhoneService : IPhoneInterface
    {
        public async Task<List<dtoTelefono>> GetTelefonos(int idUsuario)
        {
            await using (var context = new JGBANKContext())
            {
                List<Telefono> LT = context.Telefonos.Where(t => t.IdUsuario == idUsuario).ToList();
                return MapListTelefonoToListDtoTelefono(LT);
            }

        }

        public List<Telefono> MapListDtoTelefonoToListTelefono(List<dtoTelefono> LT)
        {
            List<Telefono> LD = new List<Telefono>();
            for (int i = 0; i < LT.Count(); i++)
            {
                Telefono t = new Telefono();
                t.IdTelefono = LT[i].idTelefono;
                t.IdUsuario = LT[i].idUsuario;
                t.NumTel = LT[i].numTel;

                LD.Add(t);
            }

            return LD;
        }

        private List<dtoTelefono> MapListTelefonoToListDtoTelefono(List<Telefono> LT)
        {
            List<dtoTelefono> LDT = new List<dtoTelefono>();
            for (int i = 0; i < LT.Count(); i++)
            {
                dtoTelefono dt = new dtoTelefono();
                dt.idTelefono = LT[i].IdTelefono;
                dt.idUsuario = LT[i].IdUsuario;
                dt.numTel = LT[i].NumTel;

                LDT.Add(dt);
            }

            return LDT;
        }

        List<dtoTelefono> IPhoneInterface.MapListTelefonoToListDtoTelefono(List<Telefono> LT)
        {
            throw new NotImplementedException();
        }
    }
}
