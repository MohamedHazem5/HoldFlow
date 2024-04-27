namespace HoldFlow.BL.Managers
{
    public class OrderManager : Manager<Order>, IOrderManager
    {
        public OrderManager(IOrderRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}