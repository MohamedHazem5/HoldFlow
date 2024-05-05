
namespace HoldFlow.BL.Managers
{
    public class CartItemManager : Manager<CartItem>, ICartItemManager
    {
        private readonly ICartItemRepository _repository;

        public CartItemManager(ICartItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<CartItemDto> AddToCartItem()
        {
            throw new NotImplementedException();
        }

        public async Task<GetCartItemDto> GetCartItemById(int id)
        {
            var entity =await _repository.FirstOrDefaultAsync(x => x.Id == id,c=>c.Package.Product);
            if (entity == null)
                return null;
            var cartItemDto = new GetCartItemDto
            {
                Id = entity.Id,
                Quantity = entity.Quantity,
                PackageId = entity.PackageId,
                Price = entity.Package.Price,
                ProductName = entity.Package.Product.Name

            };

            return cartItemDto;

        }
        
        public Task<CartItemDto> RemoveFromCart(int packageId)
        {
            throw new NotImplementedException();
        }
    }
}