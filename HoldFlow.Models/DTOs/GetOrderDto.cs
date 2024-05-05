using HoldFlow.Models.Enums;

namespace HoldFlow.Models.DTOs
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
        public ICollection<OrderItemDto> Items { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }

    }
}
