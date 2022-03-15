using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Services.Interfaces
{
    public interface IAccountInterface
    {
        Task<dtoCuenta> crearCuenta(int idTipo,int idUsuario,double saldo,bool estado);

        Task<string> EliminarCuenta(int idUsuario, string numeroCuenta);

        Task<dtoCuenta> getCuentaByNumCuenta(string numCuenta);

        bool getEstadoCuenta(int idCuenta);

        Task<List<dtoCuenta>> getCuentasActivas();

    }
   
}
