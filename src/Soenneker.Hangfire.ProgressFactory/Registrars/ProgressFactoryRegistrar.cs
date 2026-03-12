using Hangfire.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Hangfire.ProgressFactory.Abstract;

namespace Soenneker.Hangfire.ProgressFactory.Registrars;

/// <summary>
/// Provides additional functionality around the Hangfire progress tools
/// </summary>
public static class ProgressFactoryRegistrar
{
    /// <summary>
    /// Adds <see cref="IProgressFactory"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddProgressFactoryAsSingleton(this IServiceCollection services)
    {
        services.AddHangfireConsoleExtensions();
        services.TryAddSingleton<IProgressFactory, ProgressFactory>();

        return services;
    }
}