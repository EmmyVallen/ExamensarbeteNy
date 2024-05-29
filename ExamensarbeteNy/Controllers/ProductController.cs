using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamensarbeteNy.Models;

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
            
            return View();
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
            return View();
        }
        /*EMMY*/
        // Hantera POST-begäran för att spara den nya produkten
        [HttpPost]
        public IActionResult SkapaProdukt(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Produkter.Add(produkt);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect till startsidan eller annan lämplig plats
            }
            return View(produkt);
        }

    }
}
