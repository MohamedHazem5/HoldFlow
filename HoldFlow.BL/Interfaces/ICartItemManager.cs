using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.BL.Interfaces
{
    public interface ICartItemManager : IManager<CartItem>
    {
        public Task<GetCartItemDto> GetCartItemById(int id);
        public Task<CartItemDto> AddToCartItem();
        public Task<CartItemDto> RemoveFromCart(int packageId);
    }
}
