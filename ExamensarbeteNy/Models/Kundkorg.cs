namespace ExamensarbeteNy.Models
{
    public class Kundkorg
    {
        public int Id { get; set; }


        public List<KundkorgProdukt> KundkorgProdukter { get; set; } // Navigationsegenskap för att hämta kopplingstabellen
    }
}
