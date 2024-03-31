namespace ExamensarbeteNy.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }

        // Navigationsegenskap för att ange förhållandet till överkategori (för underkategorier)
        public int? ÖverkategoriId { get; set; }
        public Kategori Överkategori { get; set; }

        // Navigationsegenskap för att ange förhållandet till underkategorier (om en kategori har underkategorier)
        public List<Kategori> Underkategorier { get; set; }

        // Navigationsegenskap för att ange förhållandet till produkter (för produkter i denna kategori)
        public List<Produkt> Produkter { get; set; }
    }
}
