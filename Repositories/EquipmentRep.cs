using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Database.Repositories
{
    public class EquipmentRep : IRepository<Equipment>
    {
        private readonly DatabaseContext _context;

        public EquipmentRep(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Equipment entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Expression<Func<Equipment, bool>> condition)
        {
            var equipments = _context.Equipments.Where(condition);
            _context.Equipments.RemoveRange(equipments);
            await SaveAsync();
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync(Expression<Func<Equipment, bool>> condition)
        {
            IQueryable<Equipment> equipments = _context.Equipments;
            return await equipments.Where(condition).AsNoTracking().ToArrayAsync();
        }

        public async Task<Equipment> GetAsync(Expression<Func<Equipment, bool>> condition)
        {
            return await _context.Equipments.FirstOrDefaultAsync(condition);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment entity)
        {
            _context.Equipments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
