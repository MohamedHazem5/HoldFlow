namespace HoldFlow.DataAccess.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}