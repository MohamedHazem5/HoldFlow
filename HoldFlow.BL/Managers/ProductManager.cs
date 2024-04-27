namespace HoldFlow.BL.Managers
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        public ProductManager(IProductRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}