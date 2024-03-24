namespace ExamensarbeteNy.Models
{
    public class Kundkorg
    {
        public int Id { get; set; }

        // Förhållande till användaren
        public string AnvändarId { get; set; } // Foreign key för användaren
        public Användare Användare { get; set; } // Navigationsegenskap för att hämta användaren

        // Förhållande till produkter
        public List<Produkt> Produkter { get; set; } // Navigationsegenskap för att hämta produkterna i kundkorgen
    }
}
