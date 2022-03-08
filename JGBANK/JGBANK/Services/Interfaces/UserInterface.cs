using JGBANK.DTO;
using JGBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JGBANK.Services.Interfaces
{
    public interface IUserInterface
    {

        Task<Usuario> RegistrarUsuario(dtoUsuario user/*, List<Telefono> LT, List<Direccione> LD*/);
        Task<string> EliminarUsuario(long dni);
        Task<Usuario> ModificarUsuario(dtoUsuario user);

        Task<List<dtoUsuario>> GetUsuarios();

        Task<dtoUsuario> LoginUser(string Email, string Contraseña);
        Task<dtoUsuarioCuentaTarjeta> GetUsuariosConCuentasTarjetas(int numdoc);
        Task<Usuario> cargarFoto(int idUsuario, byte[] foto);
        Task<Usuario> getUserByID(int idUsuario);


        bool VerificarToken(string token);

        bool GetEstadoUsuario(int idUsuario);








    }
}
