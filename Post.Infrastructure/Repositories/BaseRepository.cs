using Microsoft.EntityFrameworkCore;
using Post.Core.Entities;
using Post.Core.Interfaces;
using Post.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Post.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PostDbContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(PostDbContext context)
        {
            _context = context;
            _entities = context.Set<T>(); 

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
