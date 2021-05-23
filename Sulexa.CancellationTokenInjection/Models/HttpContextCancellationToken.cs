using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Sulexa.CancellationTokenInjection.Models
{
    public class HttpContextCancellationToken : CancellationTokenBase
    {
        private readonly IHttpContextAccessor _context;

        public HttpContextCancellationToken(IHttpContextAccessor context)
        {
            _context = context;
        }

        public override CancellationToken Token => _context.HttpContext.RequestAborted;
    }
}
