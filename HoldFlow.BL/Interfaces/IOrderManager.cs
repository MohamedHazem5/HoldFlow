namespace HoldFlow.BL.Interfaces
{
    public interface IOrderManager : IManager<Order>
    {
        Task<GetOrderDto> GetOrderById(int id);
        Task<IEnumerable<GetOrderDto>> GetOrders();
        Task<StatusOrderDto> ConfirmOrder(int orderId);
        Task<StatusOrderDto> DenyOrder(int orderId);

    }
}
