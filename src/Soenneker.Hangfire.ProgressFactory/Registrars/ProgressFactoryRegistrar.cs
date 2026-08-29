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
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddProgressFactoryAsSingleton(this IServiceCollection services)
    {
        services.AddHangfireConsoleExtensions();
        services.TryAddSingleton<IProgressFactory, ProgressFactory>();

        return services;
    }
}
