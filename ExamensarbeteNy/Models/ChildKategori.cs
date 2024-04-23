namespace ExamensarbeteNy.Models
{
    public class ChildKategori
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }

        // Förhållande till överkategori
        public int KategoriId { get; set; } // Foreign key för överkategori
        public Kategori Kategori { get; set; } // Navigationsegenskap för att hämta överkategori
    }
}
