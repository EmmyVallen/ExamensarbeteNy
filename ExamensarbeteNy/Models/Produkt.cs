using System.ComponentModel.DataAnnotations;

namespace ExamensarbeteNy.Models

{
    public class Produkt
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Namn är obligatoriskt")]
        public string Namn { get; set; }
        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        public string Beskrivning { get; set; }
        [Required(ErrorMessage = "Pris är obligatoriskt")]
        public decimal Pris { get; set; }
        [Required(ErrorMessage = "Bild är obligatoriskt")]
        public string BildUrl { get; set; } // Egenskap för att lagra bildens sökväg

        // Förhållande till kategorin

        public int KategoriId { get; set; } // Foreign key för kategorin
        public Kategori Kategori { get; set; } // Navigationsegenskap för att hämta kategorin

        // Förhållande till child-kategori
     
        public int? ChildKategoriId { get; set; } // Foreign key för child-kategori
        public ChildKategori ChildKategori { get; set; } // Navigationsegenskap för att hämta child-kategori



        // Förhållande till bevakningar
        public List<Bevakning> Bevakningar { get; set; } = new List<Bevakning>();
    }
}
