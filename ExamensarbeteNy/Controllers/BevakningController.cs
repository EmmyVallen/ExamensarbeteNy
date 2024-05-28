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
            // Hämta alla bevakningar från databasen och inkludera relaterade data för produkt och användare
            var bevakningar = _context.Bevakningar
                .Include(b => b.Produkt)
                .Include(b => b.Användare)
                .ToList();

            // Returnera vyn och skicka med bevakningarna som modelldata
            return View(bevakningar);
        }
        [HttpPost]
        public IActionResult LäggTill(int produktId)
        {
            var bevakning = new Bevakning
            {
                ProduktId = produktId,
                AnvändarId = null // Sätt ett standardvärde som 0 eller något annat som passar din logik
            };

            // Lägg till bevakningen i databasen
            _context.Bevakningar.Add(bevakning);
            _context.SaveChanges();

            // Redirect tillbaka till sidan där användaren var
            return RedirectToAction("VisaProdukter", "Home");
        }

    }
}
