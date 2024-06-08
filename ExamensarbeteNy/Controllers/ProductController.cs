using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamensarbeteNy.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var produkter = _context.Produkter.ToList();
            return View(produkter);
        }

        /*EMMY*/
        public IActionResult VisaProdukt(int id)
        {
            ViewBag.AllCategories = _context.Kategorier.ToList();
            // Hämta produkten från databasen baserat på det angivna ID:t
            var produkt = _context.Produkter.FirstOrDefault(p => p.Id == id);

            if (produkt == null)
            {
                return NotFound();
            }

            var similarProducts = _context.Produkter
                .Where(p => p.KategoriId == produkt.KategoriId && p.Id != produkt.Id)
                .Take(4)
                .ToList();

            ViewBag.SimilarProducts = similarProducts;

            return View(produkt);
        }


        // Visa formuläret för att skapa en ny produkt
        public IActionResult SkapaProdukt()
        {
            ViewBag.Kategorier = new SelectList(_context.Kategorier, "Id", "Namn");
            ViewBag.ChildKategorier = new SelectList(_context.ChildKategorier, "Id", "Namn");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SkapaProdukt(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Produkter.Add(produkt); // Lägg till den nya produkten i DbSet
                _context.SaveChanges(); // Spara ändringarna till databasen

                return RedirectToAction("Index"); // Omdirigera till översikten av produkter
            }

            // Om modellen inte är giltig, återställ ModelState med tidigare värden
            // och återgå till vyn med de tidigare inskickade värdena
            ViewBag.Kategorier = new SelectList(_context.Kategorier, "Id", "Namn");
            ViewBag.ChildKategorier = new SelectList(_context.ChildKategorier, "Id", "Namn");
            return View(produkt);

        }
    }
}