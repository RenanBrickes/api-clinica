using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IBaseRespository<T>
    {
        void Create(T entity);
        Task<T> Read(Guid id);
        IQueryable<T> ReadAll(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Save();
    }
}
