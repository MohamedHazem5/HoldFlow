namespace HoldFlow.BL.Managers
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            var entity = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
                ImageId = productDto.ImageId
            };
            var newEntity = await _repository.AddAsync(entity);
            productDto.Id = newEntity.Id;
            return productDto;
        }

        public async Task<DeleteProductDto> DeleteProduct(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            var removedEntity = _repository.Delete(entity);
            var productDto = new DeleteProductDto
            {
                Id = removedEntity.Id,
                Name = removedEntity.Name,
            };
            return productDto;
        }

        public async Task<IEnumerable<GetProductDto>> GetCategories()
        {
            var entity = await _repository.GetAllAsync(null, p => p.Category, p => p.Image);
            var productDtos = entity.Select(x => new GetProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CategoryName = x.Name,
                ImageUrl = x.Image.Url
            });
            return productDtos;
        }

        public async Task<GetProductDto> GetProductById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id, p => p.Category, p => p.Image);
            if (entity == null)
                return null;
            var productDto = new GetProductDto
            {
                Name = entity.Name,
                Description = entity.Description,
                CategoryName = entity.Category.Name,
                ImageUrl = entity.Image.Url
            };
            return productDto;
        }

        public async Task<GetProductDto> UpdateProduct(ProductDto productDto)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == productDto.Id);
            if (entity == null)
                return null;
            entity.Name = productDto.Name;
            entity.Description = productDto.Description;
            entity.CategoryId = productDto.CategoryId;
            entity.ImageId = productDto.ImageId;
            var updatedEntity = _repository.Update(entity);
            return new GetProductDto
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Description = updatedEntity.Description,
                CategoryName = updatedEntity.Category.Name,
                ImageUrl = updatedEntity.Image.Url
            };
        }
    }
}