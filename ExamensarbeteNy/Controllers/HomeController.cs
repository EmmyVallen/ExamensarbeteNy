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
            var categories = _context.Kategorier.ToList();
            return View(categories);
        }

        public IActionResult VisaProdukter(int kategoriId)
        {
            var produkterIKategori = _context.Produkter
                .Where(p => p.KategoriId == kategoriId)
                .Include(p => p.Kategori)
                .ToList();

            return View(produkterIKategori);
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