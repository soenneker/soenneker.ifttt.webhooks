using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Ifttt.Webhooks.Abstract;

/// <summary>
/// A utility library for IFTTT webhook calling
/// </summary>
public interface IIftttWebhookUtil
{
    /// <summary>
    /// Triggers an IFTTT Webhooks event.
    /// </summary>
    /// <param name="eventName">The event name configured in the IFTTT applet.</param>
    /// <param name="key">Key used to locate the target entry.</param>
    /// <param name="value1">Value for the trigger operation.</param>
    /// <param name="value2">Value for the trigger operation.</param>
    /// <param name="value3">Value for the trigger operation.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response body returned by IFTTT.</returns>
    ValueTask<string> Trigger(string eventName, string key, string? value1 = null, string? value2 = null, string? value3 = null,
        CancellationToken cancellationToken = default);
}
