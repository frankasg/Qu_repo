using Microsoft.Extensions.DependencyInjection;
using Qu.WordFinder.Interfaces;

namespace Qu.WordFinder;

class Program
{
    static void Main(string[] args)
    {
        var host = Extensions.Builder.CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<IApplication>();
        app.Run();
    }
}