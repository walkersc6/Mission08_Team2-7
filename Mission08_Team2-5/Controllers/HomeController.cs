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
            var tasks = _repo.Tasks
                .Where(t => !(t.Completed ?? false)) // Only show incomplete tasks
                .ToList();

            return View(tasks); // Automatically uses "Index.cshtml" in the "Home" folder
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View(new Mission08_Team2_5.Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_Team2_5.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Index"); // Redirect to the Index view after adding the task
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var taskToEdit = _repo.Tasks.Single(x => x.TaskId == id);
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
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _repo.Tasks.Single(x => x.TaskId == id);
            _repo.DeleteTask(taskToDelete);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var taskToComplete = _repo.Tasks.SingleOrDefault(t => t.TaskId == id);
            if (taskToComplete != null)
            {
                taskToComplete.Completed = true;
                _repo.UpdateTask(taskToComplete);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UncompleteTask(int id)
        {
            var taskToUncomplete = _repo.Tasks.SingleOrDefault(t => t.TaskId == id);
            if (taskToUncomplete != null)
            {
                taskToUncomplete.Completed = false;
                _repo.UpdateTask(taskToUncomplete);
            }
            return RedirectToAction("Index");
        }
    }
}
