[![](https://img.shields.io/nuget/v/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ifttt.webhooks/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ifttt.webhooks/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ifttt.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ifttt.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ifttt.webhooks/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.ifttt.webhooks/actions/workflows/codeql.yml)

# Soenneker.Ifttt.Webhooks

Triggers IFTTT Webhooks events with the optional `value1`, `value2`, and `value3` ingredients.

## Install

```bash
dotnet add package Soenneker.Ifttt.Webhooks
```

## Register

```csharp
using Soenneker.Ifttt.Webhooks.Registrars;

services.AddIftttWebhookUtilAsScoped();
```

The scoped utility deliberately uses a singleton HTTP client cache. Individual utility scopes can end without destroying the long-lived client used by later calls. Use `AddIftttWebhookUtilAsSingleton()` when the utility itself should also have application lifetime.

## Trigger an event

```csharp
using Soenneker.Ifttt.Webhooks.Abstract;

public sealed class DeploymentNotifier(
    IIftttWebhookUtil webhooks,
    IConfiguration configuration)
{
    public async Task Notify(string version, CancellationToken cancellationToken)
    {
        string key = configuration["Ifttt:WebhookKey"]
            ?? throw new InvalidOperationException("Ifttt:WebhookKey is not configured");

        await webhooks.Trigger(
            eventName: "deployment_completed",
            key: key,
            value1: version,
            value2: "production",
            cancellationToken: cancellationToken);
    }
}
```

The three values are optional and are serialized as IFTTT's `value1`, `value2`, and `value3` JSON fields. `Trigger()` returns IFTTT's response body and throws `HttpRequestException` for a non-success status.

Treat the Webhooks key as a secret. It is part of IFTTT's required request path, so configure HTTP logging and tracing to redact or omit the URL before using this client in an environment that records outbound requests.
