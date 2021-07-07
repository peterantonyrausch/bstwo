using System;
using System.Threading;

namespace BS2.Foundation.Helpers
{
    public static class CancellationTokenFactory
    {
        public static CancellationToken MakeForTimeout(TimeSpan timeout)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            cts.CancelAfter(timeout);
            token.ThrowIfCancellationRequested();

            return token;
        }
    }
}