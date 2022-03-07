using JGBANK.DTO;
using JGBANK.Models;
using JGBANK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;


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
        public async Task<IActionResult> RegistrarUsuario(dtoUsuario u/*[FromQuery] List<Telefono> LT, [FromQuery] List<Direccione> LD*/)
        {
                
            try
            {
               

                Usuario user = await _userInterface.RegistrarUsuario(u,LT,LD);
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


        [Route("[controller]/CargarFoto")]
        [HttpPost]      
        public async Task<byte[]> FileUpload(IFormFile file, int idUsuario)
        {         
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    await _userInterface.cargarFoto(idUsuario, Image2Bytes(img));
                    return Image2Bytes(img);
                }
            }
        }
        [Route("[controller]/GetFoto")]
        [HttpGet]
        public async Task<string> getFoto(int idUsuario)
        {
            // Trata la información de la imagen para poder trasladarla al picturebox
            
            Usuario u =  await _userInterface.getUserByID(idUsuario);

            using (Image image = Bytes2Image(u.FotoPerfil))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }           

        }

            
        public static byte[] Image2Bytes(Image pImagen)
        {
            byte[] mImage;
            try
            {
                if (pImagen != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        pImagen.Save(ms, pImagen.RawFormat);
                        mImage = ms.GetBuffer();
                        ms.Close();
                    }
                }
                else { mImage = null; }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return mImage;
        }
        public static Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

       
    }
}
