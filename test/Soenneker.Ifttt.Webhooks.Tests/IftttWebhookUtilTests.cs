using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Ifttt.Webhooks.Abstract;
using Soenneker.Ifttt.Webhooks.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Ifttt.Webhooks.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class IftttWebhookUtilTests : HostedUnitTest
{
    private readonly IIftttWebhookUtil _util;

    public IftttWebhookUtilTests(Host host) : base(host)
    {
        _util = Resolve<IIftttWebhookUtil>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_utility_keeps_http_client_cache_singleton()
    {
        var services = new ServiceCollection();

        services.AddIftttWebhookUtilAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor webhook = services.Single(descriptor => descriptor.ServiceType == typeof(IIftttWebhookUtil));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(webhook.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
