using Soenneker.Ifttt.Webhooks.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
