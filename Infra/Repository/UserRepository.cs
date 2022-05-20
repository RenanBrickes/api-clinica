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

        public IQueryable<Usuario> GetUsers()
        {
            return ReadAll();

        }
    }
}
