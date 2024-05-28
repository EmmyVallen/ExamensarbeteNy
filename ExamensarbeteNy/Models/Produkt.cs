namespace ExamensarbeteNy.Models

{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }
        public decimal Pris { get; set; }
        public string BildUrl { get; set; } // Egenskap för att lagra bildens sökväg

        // Förhållande till kategorin
        public int KategoriId { get; set; } // Foreign key för kategorin
        public Kategori Kategori { get; set; } // Navigationsegenskap för att hämta kategorin

        // Förhållande till child-kategori
        public int? ChildKategoriId { get; set; } // Foreign key för child-kategori
        public ChildKategori ChildKategori { get; set; } // Navigationsegenskap för att hämta child-kategori


        // Förhållande till användaren
        public string AnvändarId { get; set; } // Foreign key för användaren
        public Användare Användare { get; set; } // Navigationsegenskap för att hämta användaren

        // Förhållande till bevakningar
        public List<Bevakning> Bevakningar { get; set; } // Navigationsegenskap för att hämta bevakningar
                                                         // Förhållande till kundkorg
     
    }
}
