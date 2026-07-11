using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Ifttt.Webhooks.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Ifttt.Webhooks;

/// <inheritdoc cref="IIftttWebhookUtil"/>
public sealed class IftttWebhookUtil : IIftttWebhookUtil
{
    private const string _clientId = nameof(IftttWebhookUtil);
    private const string _baseAddress = "https://maker.ifttt.com/";

    private readonly IHttpClientCache _httpClientCache;

    public IftttWebhookUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public async ValueTask<string> Trigger(string eventName, string key, string? value1 = null, string? value2 = null, string? value3 = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(eventName);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        HttpClient client = await _httpClientCache.Get(_clientId, cancellationToken);

        string encodedEventName = Uri.EscapeDataString(eventName);
        string encodedKey = Uri.EscapeDataString(key);
        string requestUri = $"{_baseAddress}trigger/{encodedEventName}/with/key/{encodedKey}";

        var payload = new IftttWebhookPayload(value1, value2, value3);

        using HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, payload, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
