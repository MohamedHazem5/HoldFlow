namespace HoldFlow.BL.Managers
{
    public class PackageManager : Manager<Package>, IPackageManager
    {
        public PackageManager(IPackageRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}