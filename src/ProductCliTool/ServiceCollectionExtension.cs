using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductCli.Core.Interfaces;
using ProductCli.Implementation;
using ProductCli.Implementation.Capterra;
using ProductCli.Implementation.Providers;
using ProductCli.Implementation.Services;
using ProductCli.Implementation.SoftwareAd;

namespace ProductCliTool
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddLogging(builder => builder.ClearProviders());
            services.AddSingleton<IProductDataProvider, InMomeryProductDataProvider>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<CapterraImporter>();
            services.AddSingleton<SoftwareAdviceImporter>();
            services.AddSingleton<IFileReaderFactory, FileReaderFactory>();
            services.AddTransient<Func<string, IProductImporter>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "capterra":
                        return serviceProvider.GetService<CapterraImporter>();
                    case "softwareadvice":
                        return serviceProvider.GetService<SoftwareAdviceImporter>();
                    default:
                        return null;
                }
            });
            return services;
        }
    }
}
