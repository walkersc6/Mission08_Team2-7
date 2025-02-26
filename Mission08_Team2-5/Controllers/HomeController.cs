using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team2_5.Models;

namespace Mission08_Team2_5.Controllers
{
    public class HomeController : Controller
    {

        private ITasksRepository _repo; //instantiating the repository as a variable
        public HomeController(ITasksRepository temp) //constructor
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            ViewBag.Tasks = _repo.Tasks.ToList(); //sending a list of tasks in the ViewBag
            
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag._repo.Categories.ToList(); //Sending the list of categories for the dropdown
            
            return View(new Task()); // sending blank task to add information to
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task); //calling the repository method to add
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var taskToEdit = _repo.Tasks
                .Single(x => x.TaskId == id); //finding the task to edit
            
            ViewBag._repo.Categories.ToList();

            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            if (ModelState.IsValid) //if statement to ensure the info follows the model structure
            {
                _repo.UpdateTask(task); //calling the repository method to update the task
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _repo.Tasks //finding task to delete
                .Single(x => x.TaskId == id);
            
            _repo.DeleteTask(taskToDelete); //call the repository method to delete the task
            return RedirectToAction("Index");
        }

    }
}
