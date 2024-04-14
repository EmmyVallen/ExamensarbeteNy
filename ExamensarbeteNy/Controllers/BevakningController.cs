using ExamensarbeteNy.Models;
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
            ViewBag.AllCategories = _context.Kategorier.ToList();
            // Hämta användarens bevakningar från databasen
            var bevakningar = _context.Bevakningar.ToList(); // Antag att Bevakningar är en DbSet i din DbContext

            return View(bevakningar);

        }
        [HttpPost]
        public IActionResult LäggTill(int produktId)
        {
            var bevakning = new Bevakning
            {
                ProduktId = produktId,
                AnvändarId = null // Sätta AnvändarId till null om det inte finns något användaridentifierare
            };

            // Lägg till bevakningen i databasen
            _context.Bevakningar.Add(bevakning);
            _context.SaveChanges();

            // Redirect tillbaka till sidan där användaren var
            return RedirectToAction("VisaProdukter", "Home");
        }

    }
}
