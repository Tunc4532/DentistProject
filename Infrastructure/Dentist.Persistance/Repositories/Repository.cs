using Dentist.Application.Interfaces;
using Dentist.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncOrderByFilter(Expression<Func<T, int>> filter)
        {
            return await _context.Set<T>().OrderBy(filter).ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<T?>> GetByFilterListAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> Include(Expression<Func<T, object>> entity)
        {
            return await _context.Set<T>().Include(entity).ToListAsync();
        }

        public async Task<List<T>> Include(Expression<Func<T, object>>[] entity)
        {
            IQueryable<T> query = _context.Set<T>();

            if (entity != null)
            {
                foreach (var include in entity)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> IncludeSingle(Expression<Func<T, object>> entity, Expression<Func<T, bool>> id)
        {
            return await _context.Set<T>().Include(entity).FirstOrDefaultAsync(id);
        }

        public async Task<List<T>> IncludeWithFilter(Expression<Func<T, object>> entity, Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Include(entity).Where(filter).ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
