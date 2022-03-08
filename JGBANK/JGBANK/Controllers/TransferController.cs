using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Controllers
{

    [Route("JGBANK")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferInterface _transferInterface;
        private readonly IAccountInterface _accountInterface;
        private readonly IUserInterface _userInterface;
        public TransferController(ITransferInterface transferInterface,IAccountInterface accountInterface,  IUserInterface userInterface)
        {
            _transferInterface = transferInterface;
            _accountInterface = accountInterface;
            _userInterface = userInterface;
        }

        [Route("[controller]/RealizarTransferencia")]
        [HttpPost]
        public async Task<IActionResult> RealizarTransferencia(double monto,int idCuentaSalida, string numCuentaDestino)
        {

            try
            {
                if (await _transferInterface.getSaldo(idCuentaSalida) > monto)
                {
                    dtoCuenta dc = await _accountInterface.getCuentaByNumCuenta(numCuentaDestino);
                    int idCuentaDestino = dc.idCuenta;
                    if (_accountInterface.getEstadoCuenta(idCuentaDestino))
                    {
                        dtoTransferencia transfer = await _transferInterface.RealizarTransferencia(monto, idCuentaSalida, idCuentaDestino);
                        return Ok(transfer);
                    }
                    else
                    {
                        return BadRequest("La cuenta a la que intenta transferir no existe!");
                    }
                    
                    
                    
                }
                else
                {
                    return BadRequest("No dispone del saldo suficiente para realizar la transacción");

                }
                

            }
            catch (Exception)
            {
                return NotFound("No responde el Servidor");
            }
        }
    }
}
