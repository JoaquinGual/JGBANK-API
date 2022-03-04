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
        
        Task<Usuario> RegistrarUsuario(dtoUsuario user);
        Task<string> EliminarUsuario(long dni);
        Task<Usuario> ModificarUsuario(dtoUsuario user);

        Task<List<dtoUsuario>> GetUsuarios();

        Task<dtoUsuario> LoginUser(string Email, string Contraseña);

        Task<List<Usuario>> GetUsuariosConCuentas(int numdoc);


        bool VerificarToken(string token);





    }
}
