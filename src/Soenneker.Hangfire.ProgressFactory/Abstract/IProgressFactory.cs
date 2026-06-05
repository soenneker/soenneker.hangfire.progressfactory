namespace Soenneker.Hangfire.ProgressFactory.Abstract;

/// <summary>
/// Provides additional functionality around the Hangfire progress tools
/// </summary>
public interface IProgressFactory
{
    /// <summary>
    /// Initializes the instance.
    /// </summary>
    /// <param name="count">The count.</param>
    void Init(int count);

    /// <summary>
    /// Executes the increment operation.
    /// </summary>
    void Increment();
}