using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamensarbeteNy.ViewModels;
using System.Diagnostics;

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
        [HttpGet]
        public IActionResult SkapaProdukt()
        {
            var model = new AnnonsViewModel
            {
                Kategorier = _context.Kategorier
                    .Select(k => new SelectListItem
                    {
                        Value = k.Id.ToString(),
                        Text = k.Namn
                    })
                    .ToList(),
                ChildKategorier = _context.ChildKategorier
                    .Select(ck => new SelectListItem
                    {
                        Value = ck.Id.ToString(),
                        Text = ck.Namn
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SkapaProdukt(AnnonsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Om valideringen misslyckas, ladda om dropdown-listorna
                model.Kategorier = _context.Kategorier
                    .Select(k => new SelectListItem
                    {
                        Value = k.Id.ToString(),
                        Text = k.Namn
                    })
                    .ToList();
                model.ChildKategorier = _context.ChildKategorier
                    .Select(ck => new SelectListItem
                    {
                        Value = ck.Id.ToString(),
                        Text = ck.Namn
                    })
                    .ToList();

                return View(model);
            }

            try
            {
                var produkt = new Produkt
                {
                    Namn = model.Namn,
                    Beskrivning = model.Beskrivning,
                    Pris = model.Pris,
                    BildUrl = model.BildUrl,
                    KategoriId = model.KategoriId,
                    ChildKategoriId = model.ChildKategoriId.Value  // Se till att ChildKategoriId är en obligatoriskt fält i modellen
                };

                _context.Produkter.Add(produkt);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                ModelState.AddModelError("", "Ett fel uppstod när annonsen skulle sparas. Försök igen senare.");
            }

            // Om något går fel, ladda om dropdown-listorna
            model.Kategorier = _context.Kategorier
                .Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Namn
                })
                .ToList();
            model.ChildKategorier = _context.ChildKategorier
                .Select(ck => new SelectListItem
                {
                    Value = ck.Id.ToString(),
                    Text = ck.Namn
                })
                .ToList();

            return View(model);
        }
    }
}