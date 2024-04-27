namespace HoldFlow.DataAccess.Repository
{
    public class BorrowItemRepository : Repository<BorrowItem>, IBorrowItemRepository
    {
        public BorrowItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}