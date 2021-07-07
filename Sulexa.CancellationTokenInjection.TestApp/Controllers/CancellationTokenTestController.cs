using Microsoft.AspNetCore.Mvc;
using Sulexa.CancellationTokenInjection.Models;
using System.Threading.Tasks;

namespace Sulexa.CancellationTokenInjection.TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CancellationTokenTestController : ControllerBase
    {
        private readonly HttpContextCancellationToken _httpContextCancellationToken;

        public CancellationTokenTestController(HttpContextCancellationToken httpContextCancellationToken)
        {
            this._httpContextCancellationToken = httpContextCancellationToken;
        }

        [HttpGet("TestCancellationAsync")]
        public async Task<ActionResult<string>> TestCancellationAsync()
        {
            await Task.Delay(10000, _httpContextCancellationToken);
            return Ok("Finished without cancellation");
        }
    }
}
