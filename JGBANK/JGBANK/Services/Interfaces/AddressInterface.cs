using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services.Interfaces
{
    public interface IAddressInterface
    {
        Task<List<dtoDireccion>> GetDirecciones(int idUsuario);
        List<Direccione> MapListDtoDireccionToListDireccion(List<dtoDireccion> LTD, int idUsuario);

        List<dtoDireccion> MapListDireccioneToListDtoDireccion(List<Direccione> LD);

    }
}
