using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JGBANK.Services.Interfaces
{
    public interface ICardInterface
    {
        Task<dtoTarjeta> CrearTarjeta(int idTipo, bool estado, int idUsuario);

        Task<string> SuspenderTarjeta(int idUsuario, string numTarjeta);
    }
}
