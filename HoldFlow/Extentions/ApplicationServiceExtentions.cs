using HoldFlow.BL;
using HoldFlow.BL.Interfaces;
using HoldFlow.BL.Managers;
using HoldFlow.DataAccess.IRepository;
using HoldFlow.DataAccess.Repository;
using MailKit;

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
            
            services.Configure<MailSettingsGmail>(configuration.GetSection("MailSettingsGmail"));

            services.AddTransient<IEmailManager, EmailManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IInventoryManager, InventoryManager>();
            services.AddScoped<IAccountManager, AccountManager>();

            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<IImageManager, ImageManager>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}