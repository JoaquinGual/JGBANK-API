using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services.Interfaces
{
    public interface ITransferInterface
    {
        Task<dtoTransferencia> RealizarTransferencia(double monto,int idCuentaSalida, int idCuentaDestino);

        Task<double> getSaldo(int idCuenta);

        Task<List<dtoTransferencia>> GetTransferenciasRealizadas(int idCuenta);

        Task<List<dtoTransferencia>> GetTransferenciasRecibidas(int idCuenta);

    }
}

