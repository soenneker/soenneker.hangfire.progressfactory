using Soenneker.Hangfire.ProgressFactory.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Hangfire.ProgressFactory.Tests;

[Collection("Collection")]
public class ProgressFactoryTests : FixturedUnitTest
{
    private readonly IProgressFactory _util;

    public ProgressFactoryTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IProgressFactory>(true);
    }

    [Fact]
    public void Default()
    {
    }
}
