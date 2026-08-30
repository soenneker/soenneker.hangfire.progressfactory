namespace Soenneker.Hangfire.ProgressFactory.Abstract;

/// <summary>
/// Tracks item-based progress for the current Hangfire job execution.
/// </summary>
public interface IProgressFactory
{
    /// <summary>
    /// Creates a progress bar and initializes its increment from the expected item count.
    /// </summary>
    /// <param name="count">Number of items or repetitions to use.</param>
    void Init(int count);

    /// <summary>
    /// Advances the current job's progress by one item, capped at 100 percent.
    /// </summary>
    void Increment();
}
