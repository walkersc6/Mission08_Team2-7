using Microsoft.EntityFrameworkCore;

namespace Mission08_Team2_5.Models
{
    public class EFTasksRepository : ITasksRepository
    {
        private TaskToCompleteContext _context;

        public EFTasksRepository(TaskToCompleteContext temp)
        {
            _context = temp;
        }

        // Eager loading Category with Tasks
        public List<Task> Tasks => _context.Tasks.Include(t => t.Category).ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}