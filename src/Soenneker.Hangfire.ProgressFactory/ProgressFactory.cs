using System;
using System.Threading;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Soenneker.Hangfire.ProgressFactory.Abstract;

namespace Soenneker.Hangfire.ProgressFactory;

/// <inheritdoc cref="IProgressFactory" />
public sealed class ProgressFactory : IProgressFactory
{
    private readonly IProgressBarFactory _factory;
    private readonly AsyncLocal<ProgressState?> _state = new();

    public ProgressFactory(IProgressBarFactory factory)
    {
        _factory = factory;
    }

    public void Init(int count)
    {
        IProgressBar progressBar = _factory.Create();
        _state.Value = new ProgressState(progressBar, count > 0 ? 100d / count : 100d);

        if (count <= 0)
            progressBar.SetValue(100);
    }

    public void Increment()
    {
        ProgressState state = _state.Value ?? throw new InvalidOperationException("Initialize the progress factory before incrementing it.");

        lock (state)
        {
            if (state.Progress >= 100)
                return;

            state.Progress = Math.Min(100, state.Progress + state.Increment);
            state.ProgressBar.SetValue(state.Progress);
        }
    }

    private sealed class ProgressState(IProgressBar progressBar, double increment)
    {
        public IProgressBar ProgressBar { get; } = progressBar;
        public double Increment { get; } = increment;
        public double Progress { get; set; }
    }
}
