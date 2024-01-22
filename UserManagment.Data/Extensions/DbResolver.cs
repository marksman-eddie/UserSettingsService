using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using UserManagment.Data.Repositories;

namespace UserManagment.Data.DbResolver
{
    public static class DbResolver
    {
        /// <summary>
        ///  AddDatabase
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");            
            services                
                .AddDbContext<ApplicationDbContext>(options => { options.UseSqlite(connectionString); });            
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILayoutRepository, LayoutRepository>();
            services.AddScoped<IUnitOfWork, AppUnitOfWork>();
        }        
    }
}
