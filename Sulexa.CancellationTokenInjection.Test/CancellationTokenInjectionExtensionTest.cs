using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sulexa.CancellationTokenInjection.Models;

namespace Sulexa.CancellationTokenInjection.Test
{
    [TestClass]
    public class CancellationTokenInjectionExtensionTest
    {

        [TestMethod]
        public void AddHttpContextCancellationTokenInjection_IHttpContextAccessor_NotNull()
        {
            var provider = Utils.CreateServiceProviderForHttpContextCancellationToken();

            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();

            Assert.IsNotNull(httpContextAccessor);
        }

        [TestMethod]
        public void AddHttpContextCancellationTokenInjection_CancellationTokenBase_NotNullAndIsHttpContextCancellationToken()
        {
            var provider = Utils.CreateServiceProviderForHttpContextCancellationToken();

            var cancelationTokenBase = provider.GetRequiredService<CancellationTokenBase>();

            Assert.IsNotNull(cancelationTokenBase);
            Assert.IsInstanceOfType(cancelationTokenBase, typeof(HttpContextCancellationToken));
        }
    }
}
