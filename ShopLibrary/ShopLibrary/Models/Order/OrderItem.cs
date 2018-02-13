namespace ShopLibrary.Models.Order
{
    public class OrderItem
    {
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
    }
}