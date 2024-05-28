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
        public IActionResult Index()
        {
            // Hämta alla produkter i kundkorgen från databasen
            var productsInCart = _context.Kundkorgar
                .Include(k => k.Produkter)
                .FirstOrDefault()?.Produkter;

            return View(productsInCart);
        }
        [HttpPost]
        public IActionResult LäggTill(int productId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaBort(int produktId)
        {
            // Hitta den specifika produkten i kundkorgen baserat på produktens ID
            var productToRemove = _context.Produkter.Find(produktId);

            if (productToRemove != null)
            {
                // Ta bort produkten från kundkorgen
                _context.Produkter.Remove(productToRemove);
                _context.SaveChanges();
            }

            // Omdirigera tillbaka till kundkorgen efter borttagning
            return RedirectToAction("Index");
        }

    }
}
