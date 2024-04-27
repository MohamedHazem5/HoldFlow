namespace HoldFlow.BL.Managers
{
    public class CartItemManager : Manager<CartItem>, ICartItemManager
    {
        public CartItemManager(ICartItemRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}