using Microsoft.EntityFrameworkCore;
using SNIC_RD.Models;

namespace SNIC_RD.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task SaveChangesAsync();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SnicRdContext _context;

        public Repository(SnicRdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
