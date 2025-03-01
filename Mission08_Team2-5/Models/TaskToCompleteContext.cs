using Microsoft.EntityFrameworkCore;

namespace Mission08_Team2_5.Models
{
    public class TaskToCompleteContext: DbContext
    {
        public TaskToCompleteContext(DbContextOptions<TaskToCompleteContext> options) : base(options) //constructor
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; } // Ensure Categories is included
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
