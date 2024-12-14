namespace Shop_WebClient.Models
{
    public class NotificationMessage
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
