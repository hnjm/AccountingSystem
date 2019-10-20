using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BL.Interfaces.Services;
using BL.Services.Services;
using DL.Interfaces.DatabaseContext;
using DL.Interfaces.Repositories;
using DL.Interfaces.UoW;
using DL.DatabaseContext.Context;
using DL.Repositories;
using DL.UnitOfWork;

namespace BL.Infrastructure
{
    public static class InjectionConfiguration
    {
        public static void Bind(IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(dbConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(10)), ServiceLifetime.Scoped);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Services            
            services.AddScoped<IOperationService, OperationService>();
            #endregion
        }
    }
}
