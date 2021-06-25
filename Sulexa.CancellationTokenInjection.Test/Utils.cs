using Microsoft.Extensions.DependencyInjection;
using Sulexa.CancellationTokenInjection.Extensions;

namespace Sulexa.CancellationTokenInjection.Test
{
    public static class Utils
    {
        public static ServiceProvider CreateServiceProviderForHttpContextCancellationToken()
        {
            var services = new ServiceCollection();
            services.AddHttpContextCancellationTokenInjection();
            return services.BuildServiceProvider();
        }
    }
}
