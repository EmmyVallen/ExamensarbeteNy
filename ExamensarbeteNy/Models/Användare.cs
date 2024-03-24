namespace ExamensarbeteNy.Models
{
    public class Användare
    {
        public string Id { get; set; } // Primary key för användaren
        public string Användarnamn { get; set; }
        public string Lösenord { get; set; }

        // Navigationsegenskap för att hämta användarens kundkorg
        public Kundkorg Kundkorg { get; set; }

        // Förhållande till bevakningar
        public List<Bevakning> Bevakningar { get; set; } // Navigationsegenskap för att hämta användarens bevakningar
    }
}
