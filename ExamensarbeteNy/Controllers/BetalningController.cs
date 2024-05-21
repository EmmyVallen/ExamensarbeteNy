using Microsoft.AspNetCore.Mvc;

namespace ExamensarbeteNy.Controllers
{
    public class BetalningController : Controller
    {
        // GET: Betalning/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Betalning/Bestallning
        public IActionResult Bestallning()
        {
            return View();
        }
    }
}

