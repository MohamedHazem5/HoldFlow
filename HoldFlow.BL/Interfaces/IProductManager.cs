namespace HoldFlow.BL.Interfaces
{
    public interface IProductManager : IManager<Product>
    {
        Task<ProductDto> AddProduct(ProductDto productDto);

        Task<GetProductDto> UpdateProduct(ProductDto productDto);

        Task<DeleteProductDto> DeleteProduct(int id);

        Task<GetProductDto> GetProductById(int id);

        Task<IEnumerable<GetProductDto>> GetCategories();
    }
}