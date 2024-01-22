using Microsoft.Extensions.DependencyInjection;
using UserManagment.Application.Interfaces;
using UserManagment.Application.Service;
using UserManagment.Core.Contracts;

namespace UserManagment.Application.Extensions
{
    //service
    public static class ServiceExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ILayoutService, LayoutService>();           
        }
    }

}
