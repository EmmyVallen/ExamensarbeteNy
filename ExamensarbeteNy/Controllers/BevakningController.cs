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
            // Hämta alla bevakningar från databasen och inkludera relaterade data för produkt och användare
            var bevakningar = _context.Bevakningar
                .Include(b => b.Produkt)
                .Include(b => b.Användare)
                .ToList();
            // Logga varje bevakning
            foreach (var bevakning in bevakningar)
            {
                _logger.LogInformation($"Bevakning Id: {bevakning.Id}, ProduktId: {bevakning.ProduktId}, AnvändarId: {bevakning.AnvändarId}");
            }

            // Logga antal bevakningar som hittades
            _logger.LogInformation($"Antal bevakningar hämtade: {bevakningar.Count}");

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

            // Logga att en bevakning har lagts till
            _logger.LogInformation($"Ny bevakning tillagd för produktId: {produktId}");

            // Redirect tillbaka till sidan där användaren var
            return RedirectToAction("VisaProdukter", "Home");
        }
    }
}