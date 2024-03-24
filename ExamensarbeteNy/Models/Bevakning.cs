namespace ExamensarbeteNy.Models
{
    public class Bevakning
    {
        public int Id { get; set; }

        // Förhållande till användaren
        public string AnvändarId { get; set; } // Foreign key för användaren
        public Användare Användare { get; set; } // Navigationsegenskap för att hämta användaren

        // Förhållande till produkten
        public int ProduktId { get; set; } // Foreign key för produkten
        public Produkt Produkt { get; set; } // Navigationsegenskap för att hämta produkten som bevakas
    }
}
