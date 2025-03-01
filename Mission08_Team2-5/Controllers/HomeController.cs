using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team2_5.Models;

namespace Mission08_Team2_5.Controllers
{
    public class HomeController : Controller
    {
        private ITasksRepository _repo;

        public HomeController(ITasksRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList();

            // Debugging output for tasks
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.TaskName}, Completed: {task.Completed}");
            }

            return View(tasks);
        }

        // this is the AddTask view 
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View(new Mission08_Team2_5.Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_Team2_5.Models.Task task)
        {
            Console.WriteLine($"Task: {task.TaskName}, Completed: {task.Completed}");

            task.Completed = task.Completed;

            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Index");
            }
    
            ViewBag.Categories = _repo.Categories.ToList();
            return View(task);
        }

        // this is the EditTask view 
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var taskToEdit = _repo.Tasks.Single(x => x.TaskId == id);
            if (taskToEdit == null)
            {
                // Return a 404 if the task doesn't exist
                return NotFound(); 
            }
    
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(Mission08_Team2_5.Models.Task task)
        {
            
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                // Explicitly return the "AddTask" view
                return View("AddTask", task); 
            }
        }

        
        // this is the DeleteTask view 
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _repo.Tasks.Single(x => x.TaskId == id);
            _repo.DeleteTask(taskToDelete);
            return RedirectToAction("Index");
        }
        
        
        // this is the CompleteTask view 
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var taskToComplete = _repo.Tasks.SingleOrDefault(t => t.TaskId == id);
            if (taskToComplete != null)
            {
                Console.WriteLine($"Before Update - Task: {taskToComplete.TaskName}, Completed: {taskToComplete.Completed}");

                taskToComplete.Completed = true;
                _repo.UpdateTask(taskToComplete);

                Console.WriteLine($"After Update - Task: {taskToComplete.TaskName}, Completed: {taskToComplete.Completed}");
            }
            return RedirectToAction("Index");
        }


        // this is the IncompleteTask view 
        [HttpPost]
        public IActionResult IncompleteTask(int id)
        {
            var taskToIncomplete = _repo.Tasks.SingleOrDefault(t => t.TaskId == id);
            if (taskToIncomplete != null)
            {
                taskToIncomplete.Completed = false;
                _repo.UpdateTask(taskToIncomplete);
            }
            return RedirectToAction("Index");
        }
    }
}
