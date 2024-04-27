namespace HoldFlow.BL.Managers
{
    public class InventoryManager : Manager<Inventory>, IInventoryManager
    {
        public InventoryManager(IInventoryRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}