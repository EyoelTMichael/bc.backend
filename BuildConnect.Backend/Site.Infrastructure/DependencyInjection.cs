using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Site.Application.Common.Interface;
using Site.Infrastructure.Data;
using System.Reflection;

namespace Site.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddDbContext<SiteAppDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            //    services.AddDbContext<IApplicationDbContext, SiteAppDbContext>(options =>
            //options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }

}
