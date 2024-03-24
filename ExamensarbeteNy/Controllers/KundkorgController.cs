using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamensarbeteNy.Controllers
{
    public class KundkorgController : Controller
    {
        public IActionResult Index()
        {
            // Implementera logik för att hämta och visa kundkorgen
            List<Produkt> kundkorg = new List<Produkt>(); // Antag att du hämtar kundkorgen från databasen eller någon annan plats
            return View(kundkorg);
        }
    }
}
