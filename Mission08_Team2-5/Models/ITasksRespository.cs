namespace Mission08_Team2_5.Models
{
    //interface

    public interface ITasksRespository
    {
        List<Task> Tasks { get; } //what needs to be put in the instance for it to be a valid class 
        
        public void AddTask(Task task);
    }
}
