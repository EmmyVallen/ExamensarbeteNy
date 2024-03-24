using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamensarbeteNy.Controllers
{
    public class BevakningController : Controller
    {
        private readonly ApplicationContext _context;

        public BevakningController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Bevakningar()
        {
            // Hämta användarens bevakningar från databasen
            var bevakningar = _context.Bevakningar.ToList(); // Antag att Bevakningar är en DbSet i din DbContext

            return View(bevakningar);

        }
    }
}
