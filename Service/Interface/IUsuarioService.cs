using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsuarioService
    {
        string GetToken(Usuario usuario);

        Task<bool> Create(Usuario usuario, string password);

        public bool HaveUserByUsername(string username);

        public bool ValidadePassword(string password);
    }
}
