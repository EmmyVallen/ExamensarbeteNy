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

        // Åtgärd för att visa en enskild produkt
        public IActionResult VisaProdukt(int id)
        {
            // Hämta produkten från databasen baserat på det angivna ID:t
            var produkt = _context.Produkter.FirstOrDefault(p => p.Id == id);

            if (produkt == null)
            {
                return NotFound(); // Returnera 404 Not Found om produkten inte hittas
            }

            return View(produkt); // Returnera vyn för att visa produkten
        }
    }
}
