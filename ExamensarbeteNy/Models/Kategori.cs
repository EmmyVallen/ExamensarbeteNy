namespace ExamensarbeteNy.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }

        // Navigationsegenskap för att ange förhållandet till child-kategorier
        public List<ChildKategori> ChildKategorier { get; set; }

        // Navigationsegenskap för att ange förhållandet till produkter (för produkter i denna kategori)
        public List<Produkt> Produkter { get; set; }
    }
}
