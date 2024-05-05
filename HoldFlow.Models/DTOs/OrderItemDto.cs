namespace HoldFlow.Models.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int PackageId { get; set; }
    }
}
