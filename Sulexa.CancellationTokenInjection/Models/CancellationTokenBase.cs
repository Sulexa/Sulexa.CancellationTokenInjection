using System.Threading;

namespace Sulexa.CancellationTokenInjection.Models
{
    public abstract class CancellationTokenBase
    {
        public abstract CancellationToken Token { get; }

        public static implicit operator CancellationToken(CancellationTokenBase requestCancellation) =>
            requestCancellation.Token;
    }
}
