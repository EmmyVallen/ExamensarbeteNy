namespace ExamensarbeteNy.Models
{
    public class Kundkorg
    {
        public int Id { get; set; }

      

        // Förhållande till produkter
        public List<Produkt> Produkter { get; set; } // Navigationsegenskap för att hämta produkterna i kundkorgen
    }
}
