using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectTrack.Application;

public static class StartupExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        
        
        return serviceCollection;
    }
}