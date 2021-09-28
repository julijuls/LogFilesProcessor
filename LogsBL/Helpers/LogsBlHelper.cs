using LogsBL.Interfaces;
using LogsBL.Services;
using LogsDAL.DBContext;
using LogsDAL.Interfaces;
using LogsDAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LogsBL.Helpers
{
    public static class LogsBlHelper
    {
        public static IServiceCollection RegisterLogsBlDependencies(this IServiceCollection services, LogsBLDIConfig dalDIConfiguration)
        {
            services.AddDbContext<LogsDbContext>(options =>
                options.UseSqlServer(dalDIConfiguration.LogsDBContextConnectionString)
            );

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogsService, LogsService>();

            return services;
        }
    }
}
