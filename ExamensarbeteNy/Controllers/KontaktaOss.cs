using ExamensarbeteNy.Models;
using Microsoft.AspNetCore.Mvc;


namespace ExamensarbeteNy.Controllers
{
    public class Controllers : Controller
    {
        // GET: KontaktaOss
        public IActionResult KontaktaOss()
        {
            return View();
        }

        // POST: KontaktaOss
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

        // En bekräftelsesida
        public IActionResult Tack()
        {
            return View();
        }
    }
}
