namespace HoldFlow.BL.Managers
{
    public class BorrowItemManager : Manager<BorrowItem>, IBorrowItemManager
    {
        public BorrowItemManager(IBorrowItemRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}