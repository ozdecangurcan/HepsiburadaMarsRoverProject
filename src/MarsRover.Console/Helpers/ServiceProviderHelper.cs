using MarsRover.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.ConsoleApp
{
    public static class ServiceProviderHelper
    {
        public static ServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddInfrastructureServices();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
