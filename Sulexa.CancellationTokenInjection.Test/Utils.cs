using Microsoft.Extensions.DependencyInjection;
using Sulexa.CancellationTokenInjection.Extensions;
using Sulexa.CancellationTokenInjection.Models;

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

        public static HttpContextCancellationToken GetHttpContextCancellationToken(ServiceProvider provider)
        {
            return provider.GetRequiredService<HttpContextCancellationToken>();
        }
    }
}
