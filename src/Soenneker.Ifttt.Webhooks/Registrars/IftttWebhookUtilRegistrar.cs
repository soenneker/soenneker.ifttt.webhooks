using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Ifttt.Webhooks.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Ifttt.Webhooks.Registrars;

/// <summary>
/// A utility library for IFTTT webhook calling
/// </summary>
public static class IftttWebhookUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IIftttWebhookUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddIftttWebhookUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<IIftttWebhookUtil, IftttWebhookUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IIftttWebhookUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddIftttWebhookUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<IIftttWebhookUtil, IftttWebhookUtil>();

        return services;
    }
}
