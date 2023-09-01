using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Database.Repositories
{
    public class TabelSizeRep : IRepository<Size>
    {
        private readonly DatabaseContext _context;

        public TabelSizeRep(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Size entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Expression<Func<Size, bool>> condition)
        {
            var sizes = _context.Sizes.Where(condition);
            _context.Sizes.RemoveRange(sizes);
            await SaveAsync();
        }

        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            return await _context.Sizes.AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<Size>> GetAllAsync(Expression<Func<Size, bool>> condition)
        {
            IQueryable<Size> sizes = _context.Sizes;
            return await sizes.Where(condition).AsNoTracking().ToArrayAsync();
        }

        public async Task<Size> GetAsync(Expression<Func<Size, bool>> condition)
        {
            return await _context.Sizes.FirstOrDefaultAsync(condition);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Size entity)
        {
            _context.Sizes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
