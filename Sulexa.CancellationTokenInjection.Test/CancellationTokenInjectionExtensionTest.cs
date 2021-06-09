using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sulexa.CancellationTokenInjection.Extensions;
using Sulexa.CancellationTokenInjection.Models;

namespace Sulexa.CancellationTokenInjection.Test
{
    [TestClass]
    public class CancellationTokenInjectionExtensionTest
    {
        private ServiceProvider CreateServiceProviderForHttpContextCancellationToken()
        {
            var services = new ServiceCollection();
            services.AddHttpContextCancellationTokenInjection();
            return services.BuildServiceProvider();
        }

        [TestMethod]
        public void AddHttpContextCancellationTokenInjection_IHttpContextAccessor_NotNull()
        {
            var provider = CreateServiceProviderForHttpContextCancellationToken();

            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();

            Assert.IsNotNull(httpContextAccessor);
        }

        [TestMethod]
        public void AddHttpContextCancellationTokenInjection_CancellationTokenBase_NotNullAndIsHttpContextCancellationToken()
        {
            var provider = CreateServiceProviderForHttpContextCancellationToken();

            var cancelationTokenBase = provider.GetRequiredService<CancellationTokenBase>();

            Assert.IsNotNull(cancelationTokenBase);
            Assert.IsInstanceOfType(cancelationTokenBase, typeof(HttpContextCancellationToken));
        }
    }
}
