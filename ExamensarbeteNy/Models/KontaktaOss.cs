namespace ExamensarbeteNy.Models
{
    public class ContactFormModel
    {
        public ContactFormModel()
        {
            Name = "";
            Subject = "";
            Message = "";
            Email = "";
            Phone = "1234567890";
        }

        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
