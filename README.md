[![](https://img.shields.io/nuget/v/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ifttt.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ifttt.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)

# Soenneker.Ifttt.Webhooks

A utility library for IFTTT webhook calling.

## Install

```bash
dotnet add package Soenneker.Ifttt.Webhooks
```

## Quick start

```csharp
using Soenneker.Ifttt.Webhooks.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddIftttWebhookUtilAsSingleton();
```

Adds `IIftttWebhookUtil` as a singleton service.

## What you get

- `IIftttWebhookUtil` — A utility library for IFTTT webhook calling.
- `IftttWebhookUtilRegistrar` — A utility library for IFTTT webhook calling.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IIftttWebhookUtil.Trigger(eventName, key, value1, value2, value3, cancellationToken)` | Triggers an IFTTT Webhooks event. | The response body returned by IFTTT. |
| `IftttWebhookUtilRegistrar.AddIftttWebhookUtilAsSingleton(services)` | Adds `IIftttWebhookUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `IftttWebhookUtilRegistrar.AddIftttWebhookUtilAsScoped(services)` | Adds `IIftttWebhookUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
