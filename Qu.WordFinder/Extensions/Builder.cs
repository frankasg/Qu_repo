using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qu.WordFinder.Interfaces;
using Qu.WordFinder.Services;

namespace Qu.WordFinder.Extensions
{
    internal static class Builder
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IApplication, Application>();
                    services.AddTransient<IWordFinder, Services.WordFinder>();
                });
    }
}
