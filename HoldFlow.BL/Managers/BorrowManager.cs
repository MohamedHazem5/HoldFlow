namespace HoldFlow.BL.Managers
{
    public class BorrowManager : Manager<Borrow>, IBorrowManager
    {
        public BorrowManager(IBorrowRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}