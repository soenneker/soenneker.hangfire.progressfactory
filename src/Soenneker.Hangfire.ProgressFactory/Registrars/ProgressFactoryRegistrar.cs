using Hangfire.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Hangfire.ProgressFactory.Abstract;

namespace Soenneker.Hangfire.ProgressFactory.Registrars;

/// <summary>
/// Registers item-based Hangfire progress tracking.
/// </summary>
public static class ProgressFactoryRegistrar
{
    /// <summary>
    /// Adds <see cref="IProgressFactory"/> as a singleton service with execution-local job state.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddProgressFactoryAsSingleton(this IServiceCollection services)
    {
        services.AddHangfireConsoleExtensions();
        services.TryAddSingleton<IProgressFactory, ProgressFactory>();

        return services;
    }
}
