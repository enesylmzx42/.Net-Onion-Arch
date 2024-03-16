using Microsoft.Extensions.DependencyInjection;
using oa.Application.Interfaces;
using oa.Application.Services;

namespace oa.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}