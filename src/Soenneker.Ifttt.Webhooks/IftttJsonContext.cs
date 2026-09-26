using System.Text.Json;
using System.Text.Json.Serialization;

namespace Soenneker.Ifttt.Webhooks;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(IftttWebhookPayload))]
internal partial class IftttJsonContext : JsonSerializerContext;
