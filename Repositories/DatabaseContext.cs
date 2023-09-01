using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VKBotBase;Username=postgres;Password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category { Id = 1, Name = "Одежда"},
                    new Category { Id = 2, Name = "Оружие"},
                    new Category { Id = 3, Name = "Снаряжение"},
                    new Category { Id = 4, Name = "Бивачное снаряжение"}
                });
        }
    }
}
