using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() { }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Work"
                },
                new Category
                {
                    Id = 2,
                    Name = "Family"
                },
                new Category
                {
                    Id = 3,
                    Name = "Birth"
                },
                new Category
                {
                    Id = 4,
                    Name = "Fun"
                },
                new Category
                {
                    Id = 5,
                    Name = "Sport"
                },
                new Category
                {
                    Id = 6,
                    Name = "Study"
                }
                );
        }
        public DbSet<Todo> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
