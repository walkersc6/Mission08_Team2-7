using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team2_5.Models;

namespace Mission08_Team2_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
