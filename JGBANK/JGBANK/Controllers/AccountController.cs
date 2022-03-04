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
    public class AccountController : ControllerBase
    {
        private readonly IAccountInterface _accountInterface;
        private readonly IUserInterface _userInterface;
        public AccountController(IAccountInterface accountInterface, IUserInterface userInterface)
        {
            _accountInterface = accountInterface;
            _userInterface = userInterface;
        }
        [Route("[controller]/CrearCuenta/{token}")]
        [HttpPost]
        public async Task<IActionResult> CrearCuenta(dtoCuenta c,string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                Cuenta account = await _accountInterface.crearCuenta(c);
                return Ok(account);
            }
            catch (Exception)
            {
                return BadRequest("Error de Conexion con el Servidor");
            }
        }
        [Route("[controller]/EliminarCuenta/{token}")]
        [HttpDelete]
        public async Task<IActionResult> EliminarCuenta(string numCuenta, string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                string mensaje = await _accountInterface.EliminarCuenta(numCuenta);
                return Ok(mensaje);
            }
            catch (Exception)
            {
                return BadRequest("Error de Conexion con el Servidor");
            }
        }
    }

}
