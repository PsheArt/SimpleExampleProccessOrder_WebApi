namespace Shop_WebClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Product { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? UserEmail { get; set; }
        public DateTime Created { get; set; }
        public bool Paid { get; set; }
    }

}
