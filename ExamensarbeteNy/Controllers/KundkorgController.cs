using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamensarbeteNy.Controllers
{
    public class KundkorgController : Controller
    {
        private readonly ApplicationContext _context;

        public KundkorgController(ApplicationContext context)
        {
            _context = context;
        }

        /*EMMY*/
        public IActionResult Index()
        {
            // Hämta alla produkter i kundkorgen från databasen
            var productsInCart = _context.Kundkorgar
                .Include(k => k.Produkter)
                .FirstOrDefault()?.Produkter;

            return View(productsInCart);
        }
        [HttpPost]
        //FUNGERAR EJ.
        public IActionResult LäggTill(int productId)
        {
            // Hämta kundvagnen från databasen, om den finns
            var kundvagn = _context.Kundkorgar
                .Include(k => k.Produkter)
                .FirstOrDefault();

            // Om kundvagnen inte finns, skapa en ny
            if (kundvagn == null)
            {
                kundvagn = new Kundkorg
                {
                    Produkter = new List<Produkt>() // Skapa en ny lista för produkterna i kundvagnen
                };

                // Lägg till kundvagnen i databasen
                _context.Kundkorgar.Add(kundvagn);
                _context.SaveChanges();
            }

            // Hämta produkten från databasen
            var produkt = _context.Produkter.Find(productId);

            // Kontrollera om produkten finns
            if (produkt != null)
            {
                // Lägg till produkten i kundvagnen
                kundvagn.Produkter.Add(produkt);

                // Spara ändringar i databasen
                _context.SaveChanges();

                // Återvänd till en vy eller sidan som indikerar att produkten har lagts till i kundvagnen
                return View();
            }
            else
            {
                // Produkten kunde inte hittas, utför lämplig åtgärd, t.ex. visa ett felmeddelande
                return RedirectToAction("ProduktSaknas", "Fel");
            }
        }

        [HttpPost]
        public IActionResult TaBort(int produktId)
        {
            // Hitta den specifika produkten i kundkorgen baserat på produktens ID
            var productToRemove = _context.Produkter.Find(produktId);

            if (productToRemove != null)
            {
                // Ta bort produkten från kundkorgen - DENNA TAR BORT FRÅN DATABASEN OCKSÅ.
                _context.Produkter.Remove(productToRemove);
                _context.SaveChanges();
            }

            // Omdirigera tillbaka till kundkorgen efter borttagning
            return RedirectToAction("Index");
        }

    }
}
