namespace HoldFlow.BL.Managers
{
    public class PackageManager : Manager<Package>, IPackageManager
    {
        private readonly IPackageRepository _repository;

        public PackageManager(IPackageRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<PackageDto> AddPackage(PackageDto packageDto)
        {
            var entity = new Package
            {
                Date = packageDto.Date,
                ExpireDate = packageDto.ExpireDate,
                Price = packageDto.Price,
                InventoryId = packageDto.InventoryId,
                left = packageDto.Stock,
                Stock = packageDto.Stock,
                ListPrice = packageDto.Price,
                ProductId = packageDto.ProductId
            };
            var newEntity = await _repository.AddAsync(entity);
            packageDto.Id = newEntity.Id;
            return packageDto;
        }

        public async Task<DeletePackageDto> DeletePackage(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            var removedEntity = _repository.Delete(entity);
            var packageDto = new DeletePackageDto
            {
                Id = removedEntity.Id,
                Date = removedEntity.Date,
                ExpireDate = removedEntity.ExpireDate,
                Price = removedEntity.Price,
                Stock = removedEntity.Stock,
            };
            return packageDto;
        }

        public async Task<IEnumerable<GetPackageDto>> GetCategories()
        {
            var entities = await _repository.GetAllAsync(null, pk => pk.Inventory, pk => pk.Product.Category, pk => pk.Product.Image);
            var packageDtos = entities.Select(x => new GetPackageDto
            {
                Id = x.Id,
                Name = x.Product.Name,
                Description = x.Product.Description,
                ListPrice = x.ListPrice,
                left = x.left,
                Date = x.Date,
                ExpireDate = x.ExpireDate,
                Price = x.Price,
                Stock = x.Stock,
                InventoryName = x.Inventory.Name,
                CategoryName = x.Product.Category.Name,
                ImageUrl = x.Product.Image.Url
            });
            return packageDtos;
        }

        public async Task<GetPackageDto> GetPackageById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id, pk => pk.Inventory, pk => pk.Product.Category, pk => pk.Product.Image);
            if (entity == null)
                return null;
            var packageDto = new GetPackageDto
            {
                Id = entity.Id,
                Name = entity.Product.Name,
                Description = entity.Product.Description,
                ListPrice = entity.ListPrice,
                left = entity.left,
                Date = entity.Date,
                ExpireDate = entity.ExpireDate,
                Price = entity.Price,
                Stock = entity.Stock,
                InventoryName = entity.Inventory.Name,
                CategoryName = entity.Product.Category.Name,
                ImageUrl = entity.Product.Image.Url
            };
            return packageDto;
        }

        public async Task<GetPackageDto> UpdatePackage(PackageDto packageDto)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == packageDto.Id);
            if (entity == null)
                return null;
            entity.Date = packageDto.Date;
            entity.ExpireDate = packageDto.ExpireDate;
            entity.Price = packageDto.Price;
            entity.left = packageDto.Stock;
            entity.Stock = packageDto.Stock;
            entity.ListPrice = packageDto.Price;
            entity.ProductId = packageDto.ProductId;
            entity.InventoryId = packageDto.InventoryId;
            var updatedEntity = _repository.Update(entity);
            var getPackageDto = new GetPackageDto
            {
                Id = entity.Id,
                Name = entity.Product.Name,
                Description = entity.Product.Description,
                ListPrice = entity.ListPrice,
                left = entity.left,
                Date = entity.Date,
                ExpireDate = entity.ExpireDate,
                Price = entity.Price,
                Stock = entity.Stock,
                InventoryName = entity.Inventory.Name,
                CategoryName = entity.Product.Category.Name,
                ImageUrl = entity.Product.Image.Url
            };
            return getPackageDto;
        }
    }
}