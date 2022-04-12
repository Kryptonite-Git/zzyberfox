using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Core.Repositories.Base;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UserContext _UserContext;
        public Repository(UserContext UserContext)
        {
            _UserContext = UserContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _UserContext.Set<T>().AddAsync(entity);
            await _UserContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _UserContext.Set<T>().Remove(entity);
            await _UserContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _UserContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _UserContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
