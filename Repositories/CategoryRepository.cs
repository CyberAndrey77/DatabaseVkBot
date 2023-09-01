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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<Category, bool>> condition)
        {
            var computers = _context.Categories.Where(condition);
            _context.Categories.RemoveRange(computers);
            await SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> condition)
        {
            IQueryable<Category> computers = _context.Categories;
            return await computers.Where(condition).AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> condition)
        {
            return await _context.Categories.FirstOrDefaultAsync(condition);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await SaveAsync();
        }
    }
}
