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
            ViewBag.Tasks = _repo.Tasks.ToList();
            
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag._repo.Categories.ToList();
            
            return View(new Task());
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
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
                .Single(x => x.TaskId == id);
            
            ViewBag._repo.Categories.ToList();

            return View("AddTask", taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
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
            var taskToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);
            
            _repo.DeleteTask(taskToDelete);
            return RedirectToAction("Index");
        }

    }
}
