using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ThingRepository : IRepository<Thing>
    {
        private readonly DatabaseContext _context;

        public ThingRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Thing entity)
        {
            await _context.Things.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Expression<Func<Thing, bool>> condition)
        {
            var computers = _context.Things.Where(condition);
            _context.Things.RemoveRange(computers);
            await SaveAsync();
        }

        public async Task<IEnumerable<Thing>> GetAllAsync()
        {
            return await _context.Things.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Thing>> GetAllAsync(Expression<Func<Thing, bool>> condition)
        {
            IQueryable<Thing> computers = _context.Things;
            return await computers.Where(condition).AsNoTracking().ToListAsync();
        }

        public async Task<Thing> GetAsync(Expression<Func<Thing, bool>> condition)
        {
            return await _context.Things.FirstOrDefaultAsync(condition);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Thing entity)
        {
            _context.Things.Update(entity);
            await SaveAsync();
        }
    }
}
