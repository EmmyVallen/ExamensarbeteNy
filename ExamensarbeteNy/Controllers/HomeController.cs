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

        public IActionResult Index()
        {

            var categoriesWithChildren = _context.Kategorier.Include(k => k.ChildKategorier).ToList();
            ViewBag.AllCategories = categoriesWithChildren;
            ViewBag.AboutLink = Url.Action("About", "Home");
            ViewBag.TermsLink = Url.Action("Terms", "Home");
            return View();
        }

        public IActionResult VisaProdukter(int? kategoriId, string pris)
        {
            IQueryable<Produkt> produkterIKategori = _context.Produkter.Include(p => p.Kategori); // Inkludera kategorin för att undvika fel
            var categoriesWithChildren = _context.Kategorier.Include(k => k.ChildKategorier).ToList(); // Inkludera även child-kategorier för att skicka till vyn

            // Filtrera efter kategori om en kategori valdes
            if (kategoriId.HasValue)
            {
                produkterIKategori = produkterIKategori.Where(p => p.KategoriId == kategoriId.Value);
            }

            // Filtrera efter prisintervall om ett prisintervall valdes
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
        public IActionResult Frakt()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/Frakt.cshtml");
        }
        public IActionResult Skydd()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/Skydd.cshtml");
        }

        public IActionResult KläderTips()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/KläderTips.cshtml");
        }
        public IActionResult InredningTips()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/InredningTips.cshtml");
        }
        public IActionResult Diy()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/Diy.cshtml");
        }

        public IActionResult Begagnat()
        {
            // Här kan du lägga kod för att visa sidan för frakt
            return View("~/Views/Begagnat.cshtml");
        }



        public IActionResult About()
        {
            return View();
        }

        public IActionResult Terms()
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