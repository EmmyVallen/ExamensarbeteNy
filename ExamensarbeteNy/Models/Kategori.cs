namespace ExamensarbeteNy.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }

        // Navigationsegenskap för att ange förhållandet till produkter
        public List<Produkt> Produkter { get; set; }
    }
}
