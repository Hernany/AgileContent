using CanditateTesting.HernanySantos.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CanditateTesting.HernanySantos.Helpers
{
    public class Config
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConvertLogService, ConvertLogService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IFileService, FileService>();
        }
    }
}