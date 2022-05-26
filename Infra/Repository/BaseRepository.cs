using Domain.Context;
using Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> Read(Guid id)
        {
            return await _context.FindAsync<T>(id.ToString());
        }

        public IQueryable<T> ReadAll(Expression<Func<T, bool>> expression = null)
        {
            var query = _context
                .Set<T>()
                .AsQueryable();

            if (expression != null)
                query = query.Where(expression);

            return query;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
