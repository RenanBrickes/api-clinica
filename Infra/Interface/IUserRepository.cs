using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IUserRepository
    {
        IQueryable<Usuario> GetUsers();
        Task<Usuario> GetUserById(Guid userId);
        void DeleteUser(Usuario user);
        Task<bool> SaveUser();
    }
}
