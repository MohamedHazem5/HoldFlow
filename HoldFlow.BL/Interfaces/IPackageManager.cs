namespace HoldFlow.BL.Interfaces
{
    public interface IPackageManager : IManager<Package>
    {
        Task<PackageDto> AddPackage(PackageDto packageDto);

        Task<GetPackageDto> UpdatePackage(PackageDto packageDto);

        Task<DeletePackageDto> DeletePackage(int id);

        Task<GetPackageDto> GetPackageById(int id);
        Task<StatusOrderDto> UpdateStocksInPackage(List<OrderItem> orderItemsList);

        Task<IEnumerable<GetPackageDto>> GetPackages();
    }
}