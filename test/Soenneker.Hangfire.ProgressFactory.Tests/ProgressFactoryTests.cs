using Soenneker.Hangfire.ProgressFactory.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Hangfire.ProgressFactory.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ProgressFactoryTests : HostedUnitTest
{
    private readonly IProgressFactory _util;

    public ProgressFactoryTests(Host host) : base(host)
    {
        _util = Resolve<IProgressFactory>(true);
    }

    [Test]
    public void Default()
    {
    }
}
