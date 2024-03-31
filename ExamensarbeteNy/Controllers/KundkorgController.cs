using ExamensarbeteNy.Models;
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
        public IActionResult Index()
        {
            ViewBag.AllCategories = _context.Kategorier.ToList();
            return View();
        }

    }
}
