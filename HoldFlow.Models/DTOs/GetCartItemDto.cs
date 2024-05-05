namespace HoldFlow.Models.DTOs
{
    public class GetCartItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PackageId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

    }
}
