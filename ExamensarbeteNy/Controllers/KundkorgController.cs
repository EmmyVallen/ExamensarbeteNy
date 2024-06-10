using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Http;
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
            var kundkorgId = 1; // Antag att kundkorgId är 1 för detta exempel

            // Hämta produkterna från kundkorgsprodukter baserat på kundkorgens id
            var kundkorgProdukter = _context.KundkorgProdukter
                                            .Where(kp => kp.KundkorgId == kundkorgId)
                                            .Include(kp => kp.Produkt)
                                            .Select(kp => kp.Produkt)
                                            .ToList();

            return View(kundkorgProdukter);
        }


        [HttpPost]
        public IActionResult LäggTill(int produktId)
        {
            var kundkorgId = 1; // Antag att kundkorgId är 1 för detta exempel

            var produkt = _context.KundkorgProdukter
                                  .Include(kp => kp.Produkt)
                                  .FirstOrDefault(kp => kp.ProduktId == produktId && kp.KundkorgId == kundkorgId)?.Produkt;

            if (produkt != null)
            {
                // Produkten finns i kundkorgen, du kan göra vad som krävs här
                // Till exempel: ange en meddelande att produkten redan finns i kundkorgen
            }
            else
            {
                // Produkten finns inte i kundkorgen, lägg till den
                var kundkorgProdukt = new KundkorgProdukt
                {
                    ProduktId = produktId,
                    KundkorgId = kundkorgId
                };

                _context.KundkorgProdukter.Add(kundkorgProdukt);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
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

