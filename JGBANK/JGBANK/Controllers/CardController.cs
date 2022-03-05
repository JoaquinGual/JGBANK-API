using JGBANK.DTO;
using JGBANK.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JGBANK.Controllers
{
    [Route("JGBANK")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardInterface _cardInterface;
        private readonly IUserInterface _userInterface;

        public CardController(ICardInterface cardInterface, IUserInterface userInterface)
        {
            _cardInterface = cardInterface;
            _userInterface = userInterface;
        }

        [Route("[controller]/RegistrarTarjeta/{token}")]
        [HttpPost]
        public async Task<IActionResult> CrearTarjeta(int idTipo, bool estado, int idUsuario, string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                dtoTarjeta dt = await _cardInterface.CrearTarjeta(idTipo,estado,idUsuario);
                return Ok(dt);
            }
            catch (Exception)
            {
                return NotFound("No responde el Servidor");
            }
        }
        [Route("[controller]/SuspenderTarjeta/{token}")]
        [HttpDelete]
        public async Task<IActionResult> SuspenderTarjeta(int idUsuario, string numeroTarjeta,string token)
        {
            try
            {
                if (!_userInterface.VerificarToken(token))
                {
                    return BadRequest("Error al validad Identidad");
                }
                string mensaje = await _cardInterface.SuspenderTarjeta(idUsuario,numeroTarjeta);
                return Ok(mensaje);
            }
            catch (Exception)
            {
                return NotFound("No responde el Servidor");
            }
        }
    }
}
