[![](https://img.shields.io/nuget/v/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ifttt.webhooks/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ifttt.webhooks/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ifttt.webhooks.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ifttt.webhooks/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Ifttt.Webhooks
### A utility library for IFTTT webhook calling

## Installation

```shell
dotnet add package Soenneker.Ifttt.Webhooks
```

## Registration

```csharp
services.AddIftttWebhookUtilAsSingleton();
```

The scoped registration is also available through `AddIftttWebhookUtilAsScoped()`.

## Usage

```csharp
string response = await webhookUtil.Trigger(
    eventName: "order_created",
    key: "your-ifttt-webhooks-key",
    value1: "12345",
    value2: "Ada Lovelace");
```

`Trigger` sends a JSON `POST` to the IFTTT Webhooks service. The three value arguments are optional, and the returned string is the response body from IFTTT. Non-success HTTP responses throw an `HttpRequestException`.
