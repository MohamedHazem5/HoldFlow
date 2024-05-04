namespace HoldFlow.BL.Managers
{
    public class InventoryManager : Manager<Inventory>, IInventoryManager
    {
        private readonly IInventoryRepository _repository;

        public InventoryManager(IInventoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<InventoryDto> AddInventory(InventoryDto inventoryDto)
        {
            var inventory = new Inventory
            {
                Name = inventoryDto.Name
            };
            var newEntity = await _repository.AddAsync(inventory);
            inventoryDto.Id = newEntity.Id;
            return inventoryDto;
        }

        public async Task<InventoryDto> DeleteInventory(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;

            var removedEntity = _repository.Delete(entity);

            var inventoryDto = new InventoryDto
            {
                Id = removedEntity.Id,
                Name = removedEntity.Name
            };
            return inventoryDto;
        }

        public async Task<IEnumerable<InventoryDto>> GetCategories()
        {
            var entities = await _repository.GetAllAsync();
            var inventoryDtos = entities.Select(x => new InventoryDto
            {
                Id = x.Id,
                Name = x.Name
            });
            return inventoryDtos;
        }

        public async Task<InventoryDto> GetInventoryById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            var inventoryDto = new InventoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return inventoryDto;
        }

        public async Task<InventoryDto> UpdateInventory(InventoryDto inventoryDto)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == inventoryDto.Id);
            if (entity == null)
                return null;
            entity.Name = inventoryDto.Name;
            var updatedEntity = _repository.Update(entity);
            return inventoryDto;
        }
    }
}