namespace HoldFlow.BL.Interfaces
{
    public interface IInventoryManager : IManager<Inventory>
    {
        Task<InventoryDto> AddInventory(InventoryDto inventoryDto);

        Task<InventoryDto> UpdateInventory(InventoryDto inventoryDto);

        Task<InventoryDto> DeleteInventory(int id);

        Task<InventoryDto> GetInventoryById(int id);

        Task<IEnumerable<InventoryDto>> GetInventories();
    }
}