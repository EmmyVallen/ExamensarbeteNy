using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamensarbeteNy.Controllers
{
     public class BevakningController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<BevakningController> _logger;

        public BevakningController(ApplicationContext context, ILogger<BevakningController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Bevakningar()
        {

            // Hämta bevakningar från databasen med relaterad produktinformation
            var bevakningarMedProduktInfo = _context.Bevakningar
                .Include(b => b.Produkt) // Anslut till Produkt för att få produktens detaljer
                .ToList();

            // Skicka bevakningarna till vyn som en modell
            return View(bevakningarMedProduktInfo);
        }

        [HttpPost]
        public IActionResult LäggTill(int produktId)
        {
            // Skapa en ny bevakning för den angivna produkten
            var bevakning = new Bevakning
            {
                ProduktId = produktId
            };

            // Lägg till bevakningen i databasen
            _context.Bevakningar.Add(bevakning);
            _context.SaveChanges();

            // Redirect tillbaka till produktsidan eller annan lämplig sida
            return RedirectToAction("Index", "Home");
        }
        public IActionResult TaBort(int id)
        {
            // Hämta bevakningen från databasen
            var bevakning = _context.Bevakningar.FirstOrDefault(b => b.Id == id);

            if (bevakning != null)
            {
                // Ta bort bevakningen från databasen
                _context.Bevakningar.Remove(bevakning);
                _context.SaveChanges();
            }

            // Omdirigera tillbaka till bevakningslistan
            return RedirectToAction("Bevakningar");
        }

    }
}