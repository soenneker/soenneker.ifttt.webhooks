using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Ifttt.Webhooks.Abstract;

/// <summary>
/// Triggers IFTTT Webhooks events with up to three optional values.
/// </summary>
public interface IIftttWebhookUtil
{
    /// <summary>
    /// Triggers an IFTTT Webhooks event.
    /// </summary>
    /// <param name="eventName">The event name configured in the IFTTT applet.</param>
    /// <param name="key">The private Webhooks service key.</param>
    /// <param name="value1">The optional first ingredient exposed to the applet.</param>
    /// <param name="value2">The optional second ingredient exposed to the applet.</param>
    /// <param name="value3">The optional third ingredient exposed to the applet.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response body returned by IFTTT after a successful request.</returns>
    ValueTask<string> Trigger(string eventName, string key, string? value1 = null, string? value2 = null, string? value3 = null,
        CancellationToken cancellationToken = default);
}
