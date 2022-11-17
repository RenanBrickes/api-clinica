using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Infra.Interface;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Domain.Context;

namespace Infra.Repository
{
    public class UserRepository : BaseRepository<Usuario>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public void DeleteUser(Usuario user)
        {
            Delete(user);
        }

        public async Task<Usuario> GetUserById(Guid userId)
        {
            return await Read(userId);
        }

        public IQueryable<Usuario> GetUsers()
        {
            return ReadAll();

        }

        public async Task<bool> SaveUser()
        {
            return await Save();
        }
    }
}
