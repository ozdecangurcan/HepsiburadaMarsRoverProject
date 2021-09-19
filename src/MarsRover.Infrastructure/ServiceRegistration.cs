using MarsRover.Application.Interfaces.Services;
using MarsRover.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRoverService, RoverService>();
            serviceCollection.AddTransient<IPlateauService, PlateauService>();
            serviceCollection.AddTransient<IDeploymentPointService, DeploymentPointService>();
        }
    }
}
