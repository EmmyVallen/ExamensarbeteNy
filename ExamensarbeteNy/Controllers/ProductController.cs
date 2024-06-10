using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamensarbeteNy.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ApplicationContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
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
            // Hämta befintliga kategorier och underkategorier från databasen
            var kategorier = _context.Kategorier.ToList();
            ViewBag.Kategorier = kategorier;
            var childKategorier = _context.ChildKategorier.ToList();
            ViewBag.ChildKategorier = childKategorier;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SkapaProdukt(Produkt produkt)
        {
            if (produkt.KundkorgProdukter == null)
            {
                ModelState.Remove("KundkorgProdukter");
            }
            if (ModelState.IsValid)
            {
                _context.Produkter.Add(produkt);
                _context.SaveChanges();
                _logger.LogInformation("Ny produkt skapad: {ProduktNamn}", produkt.Namn); // Logga information om den nya produkten
                return RedirectToAction("Index", "Home");
            }

            _logger.LogError("ModelState är inte giltig");

            // Logga ModelState-fel
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

          
            ViewBag.Kategorier = _context.Kategorier.ToList();
            ViewBag.ChildKategorier = _context.ChildKategorier.ToList();

            return View(produkt);
        }
    }
}