using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Messages.Base.Tests;

[Collection("Collection")]
public class MessageTests : FixturedUnitTest
{
    public MessageTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
