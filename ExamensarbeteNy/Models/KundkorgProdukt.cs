namespace ExamensarbeteNy.Models
{
    public class KundkorgProdukt
    {
        public int Id { get; set; }
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
        public int KundkorgId { get; set; }
        public Kundkorg Kundkorg { get; set; }
    }
}
