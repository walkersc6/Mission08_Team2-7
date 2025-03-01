namespace Mission08_Team2_5.Models
{
    //interface

    public interface ITasksRepository
    {
        List<Task> Tasks { get; } //what needs to be put in the instance for it to be a valid class 
        List<Category> Categories { get; } // Add this line to expose Categories

        
        public void AddTask(Task task);
        public void UpdateTask(Task task); // Add missing methods to match repository implementation
        public void DeleteTask(Task task);
    }
}
