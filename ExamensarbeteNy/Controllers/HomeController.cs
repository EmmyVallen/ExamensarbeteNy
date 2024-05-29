using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExamensarbeteNy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        /*EMMY*/
        public IActionResult Index()
        {
            var categoriesWithChildren = _context.Kategorier.Include(k => k.ChildKategorier).ToList();
            ViewBag.AllCategories = categoriesWithChildren;
            ViewBag.AboutLink = Url.Action("About", "Home");
            ViewBag.TermsLink = Url.Action("Terms", "Home");
            return View();
        }
        /*EMMY*/
        public IActionResult VisaProdukter(int? kategoriId, string pris)
        {
            IQueryable<Produkt> produkterIKategori = _context.Produkter.Include(p => p.Kategori);
            var categoriesWithChildren = _context.Kategorier.Include(k => k.ChildKategorier).ToList();

            if (kategoriId.HasValue)
            {
                produkterIKategori = produkterIKategori.Where(p => p.KategoriId == kategoriId.Value);
            }

            if (!string.IsNullOrEmpty(pris))
            {
                var priceRange = pris.Split('-').Select(int.Parse).ToArray();
                var minPrice = priceRange[0];
                var maxPrice = priceRange[1];

                produkterIKategori = produkterIKategori.Where(p => p.Pris >= minPrice && p.Pris <= maxPrice);
            }

            ViewBag.AllCategories = categoriesWithChildren;
            return View(produkterIKategori.ToList());
        }

  

        public IActionResult KontaktaOss()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KontaktaOss(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Hantera formulärdata, t.ex. skicka e-post eller spara i databasen.
                return RedirectToAction("Tack");
            }

            // Om modellen är ogiltig, visa formuläret igen med valideringsmeddelanden.
            return View(model);
        }

        public IActionResult Tack()
        {
            return View();
        }

        // Andra åtgärder och metoder...

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }
        public IActionResult Diy()
        {
            return View();
        }
        public IActionResult InredningTips()
        {
            return View();
        }
        public IActionResult Frakt()
        {
            return View();
        }
        public IActionResult Begagnat()
        {
            return View();
        }
        public IActionResult KläderTips()
        {
            return View();
        }
        public IActionResult Skydd()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
