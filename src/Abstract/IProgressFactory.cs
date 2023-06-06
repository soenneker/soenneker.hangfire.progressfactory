namespace Soenneker.Hangfire.ProgressFactory.Abstract;

/// <summary>
/// Provides additional functionality around the Hangfire progress tools
/// </summary>
public interface IProgressFactory
{
    void Init(int count);

    void Increment();
}