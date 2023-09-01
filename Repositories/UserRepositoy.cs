using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Database.Repositories
{
    public class UserRepositoy : IRepository<User>
    {
        private readonly DatabaseContext _context;
        public UserRepositoy(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(Expression<Func<User, bool>> condition)
        {
            var users = _context.Users.Where(condition);
            _context.Users.RemoveRange(users);
            await SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> condition)
        {
            IQueryable<User> users = _context.Users;
            return await users.Where(condition).AsNoTracking().ToArrayAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.FirstOrDefaultAsync(condition);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
