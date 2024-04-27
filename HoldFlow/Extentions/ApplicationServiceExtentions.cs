using HoldFlow.BL.Interfaces;
using HoldFlow.BL.Managers;
using HoldFlow.DataAccess.IRepository;
using HoldFlow.DataAccess.Repository;

namespace HoldFlow.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IInventoryManager, InventoryManager>();
            return services;
        }
    }
}