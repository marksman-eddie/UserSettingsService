using UserManagment.Data.DbResolver;

namespace UserManagment.Presentation.Extensions
{
    public static class DatabaseExtensions
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);            
            services.RegisterRepositories();
        }
    }

}
