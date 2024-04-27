namespace HoldFlow.DataAccess.Repository
{
    public class BorrowRepository : Repository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}