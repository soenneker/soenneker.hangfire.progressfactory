using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Soenneker.Hangfire.ProgressFactory.Abstract;

namespace Soenneker.Hangfire.ProgressFactory;

///<inheritdoc cref="IProgressFactory"/>
public sealed class ProgressFactory : IProgressFactory
{
    private readonly IProgressBarFactory _factory;
    private IProgressBar? _progressBar;

    private double _progressCount;
    private double _increment;

    public ProgressFactory(IProgressBarFactory factory)
    {
        _factory = factory;
    }

    public void Init(int count)
    {
        _increment = (double) 100 / count;
        _progressBar = _factory.Create();
        _progressCount = 0;
    }

    public void Increment()
    {
        _progressCount += _increment;

        if (_progressCount >= 100)
            return;

        if (_progressCount + _increment > 100)
            _progressBar!.SetValue(100);
        else
            _progressBar!.SetValue(_progressCount);
    }
}