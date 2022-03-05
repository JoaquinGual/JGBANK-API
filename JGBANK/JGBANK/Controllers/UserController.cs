using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Controllers
{
    [Route("JGBANK")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [Route("[controller]/RegistrarUsuario")]
        [HttpPost]
       public async Task<IActionResult> RegistrarUsuario(dtoUsuario u)
        {
                
            try
            {
               

                Usuario user = await _userInterface.RegistrarUsuario(u);
                return Ok(user);
            }
            catch (Exception)
            {
                return NotFound("No responde el Servidor");
            }
        }
        [Route("[controller]/ModificarUsuario/{token}")]
        [HttpPut]
        public async Task<IActionResult> ModificarUsuario(dtoUsuario u,string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                Usuario user = await _userInterface.ModificarUsuario(u);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Error de Conexion al Servidor ");
            }
        }
        [Route("[controller]/GetUsuarios/{token}")]
        [HttpGet]
        public async Task<IActionResult> GetUsuarios(string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }

                List<dtoUsuario> LDU = await _userInterface.GetUsuarios();
                return Ok(LDU);
            }
            catch (Exception)
            {
                return BadRequest("Error de Conexion al Servidor");
            }
        }
        [Route("[controller]/LoginUser")]
        [HttpGet]
        public async Task<IActionResult> LoginUser(string Email, string Contraseña)
        {
            try
            {   
                dtoUsuario du = await _userInterface.LoginUser(Email,Contraseña);
                return Ok(du);
            }
            catch (Exception)
            {

                return BadRequest("Error al conectar con el Servidor!");
            }
        }
        [Route("[controller]/EliminarUsuario/{token}")]
        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario(long dni,string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                string respuesta = await _userInterface.EliminarUsuario(dni);
                return Ok(respuesta);
            }
            catch (Exception)
            {
                return BadRequest("Error de Conexion con el Servidor!");
            }
        }
        [Route("[controller]/GetUsuariosConCuentasTarjetas/{token}")]
        [HttpGet]
        public async Task<IActionResult> GetUsuariosConCuentasTarjetas(int numdoc,string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                dtoUsuarioCuentaTarjeta dut = await _userInterface.GetUsuariosConCuentasTarjetas(numdoc);
                return Ok(dut);
            }
            catch (Exception)
            {
                return BadRequest("Error al conectar con el Servidor!");
            }
        }
    }
}
