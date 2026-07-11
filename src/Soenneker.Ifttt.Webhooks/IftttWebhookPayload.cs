using System.Text.Json.Serialization;

namespace Soenneker.Ifttt.Webhooks;

internal sealed record IftttWebhookPayload(
    [property: JsonPropertyName("value1")] string? Value1,
    [property: JsonPropertyName("value2")] string? Value2,
    [property: JsonPropertyName("value3")] string? Value3);
