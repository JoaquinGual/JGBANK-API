using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services.Interfaces
{
    public interface IPhoneInterface
    {
        Task<List<dtoTelefono>> GetTelefonos(int idUsuario);

        List<dtoTelefono> MapListTelefonoToListDtoTelefono(List<Telefono> LT);
        List<Telefono> MapListDtoTelefonoToListTelefono(List<dtoTelefono> LT);
    }
}
