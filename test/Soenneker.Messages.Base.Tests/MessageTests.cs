using Soenneker.Tests.HostedUnit;

namespace Soenneker.Messages.Base.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class MessageTests : HostedUnitTest
{
    public MessageTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
