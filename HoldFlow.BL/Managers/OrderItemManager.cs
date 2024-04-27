namespace HoldFlow.BL.Managers
{
    public class OrderItemManager : Manager<OrderItem>, IOrderItemManager
    {
        public OrderItemManager(IOrderItemRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}