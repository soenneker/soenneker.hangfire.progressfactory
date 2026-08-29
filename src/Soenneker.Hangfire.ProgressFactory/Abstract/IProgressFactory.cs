namespace Soenneker.Hangfire.ProgressFactory.Abstract;

/// <summary>
/// Provides additional functionality around the Hangfire progress tools
/// </summary>
public interface IProgressFactory
{
    /// <summary>
    /// Initializes the instance.
    /// </summary>
    /// <param name="count">Number of items or repetitions to use.</param>
    void Init(int count);

    /// <summary>
    /// Increment on the Progress Factory.
    /// </summary>
    void Increment();
}
