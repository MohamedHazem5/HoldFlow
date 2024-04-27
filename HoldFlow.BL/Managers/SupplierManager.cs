namespace HoldFlow.BL.Managers
{
    public class SupplierManager : Manager<Supplier>, ISupplierManager
    {
        public SupplierManager(ISupplierRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}