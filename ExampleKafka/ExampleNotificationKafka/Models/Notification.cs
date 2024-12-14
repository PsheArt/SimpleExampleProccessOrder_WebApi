namespace ExampleNotificationKafka.Models
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        //public int NotificationId { get; set; }
        // public Guid OrderId { get; set; }
        public int OrderId { get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
    }
}
