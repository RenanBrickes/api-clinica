using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsuarioService
    {
        string GetToken(Usuario usuario);

        Task<bool> Create(Usuario usuario, string password);

        IQueryable<Usuario> GetUsers();

        Task<Usuario> GetUserById(Guid userId);

        Task<bool> DeleteUser(Usuario user);

        public bool HaveUserByUsername(string username);

        public bool ValidadePassword(string password);
        
    }
}
