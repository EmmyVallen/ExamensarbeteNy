using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ExamensarbeteNy.ViewModels
{
    public class AnnonsViewModel
    {
        [Required(ErrorMessage = "Namn är obligatoriskt")]
        public string Namn { get; set; }

        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "Pris är obligatoriskt")]
        public decimal Pris { get; set; }

        [Required(ErrorMessage = "Bild är obligatoriskt")]
        public string BildUrl { get; set; }

   
        public int KategoriId { get; set; }

        public int? ChildKategoriId { get; set; }

        // Dropdown-listor
        public List<SelectListItem> Kategorier { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ChildKategorier { get; set; } = new List<SelectListItem>();
    }
}
