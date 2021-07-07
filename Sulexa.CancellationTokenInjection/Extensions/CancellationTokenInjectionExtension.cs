using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sulexa.CancellationTokenInjection.Models;

namespace Sulexa.CancellationTokenInjection.Extensions
{
    public static class CancellationTokenInjectionExtension
    {

        /// <summary>
        /// Add HttpContextRequestCancellation injection
        /// </summary>
        /// <param name="services">Startup service collection</param>
        public static void AddHttpContextCancellationTokenInjection(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<HttpContextCancellationToken>();
        }
    }
}
