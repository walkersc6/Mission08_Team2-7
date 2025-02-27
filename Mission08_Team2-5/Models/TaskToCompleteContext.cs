using Microsoft.EntityFrameworkCore;

namespace Mission08_Team2_5.Models
{
    public class TaskToCompleteContext: DbContext
    {
        public TaskToCompleteContext(DbContextOptions<TaskToCompleteContext> options) : base(options) //constructor
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
