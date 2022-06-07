using LiteDB.Async;
using Microsoft.Extensions.DependencyInjection;
using ProjectTrack.Application.Common.Interfaces;

namespace ProjectTrack.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ILiteDatabaseAsync>(_ => new LiteDatabaseAsync("projectTrack"));
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        
        return serviceCollection;
    }
}