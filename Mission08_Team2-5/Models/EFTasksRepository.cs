namespace Mission08_Team2_5.Models
{ 
    //individual instances
    public class EFTasksRepository : ITasksRespository
    {
        private TaskToCompleteContext _context;
        public EFTasksRepository(TaskToCompleteContext temp) //contructor
        {
            _context = temp;
        }
        public List<Task> Tasks => _context.Tasks.ToList(); //gets all tasks and saves them to a list of type task

        public void AddTask(Task task) //add new task to the database
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task) //update task in the database
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task) //delete task from the database
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
