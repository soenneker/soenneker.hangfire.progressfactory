[![](https://img.shields.io/nuget/v/Soenneker.Hangfire.ProgressFactory.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ProgressFactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.progressfactory/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.progressfactory/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.progressfactory/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.hangfire.progressfactory/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Hangfire.ProgressFactory.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ProgressFactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.progressfactory/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.progressfactory/actions/workflows/codeql.yml)

# Soenneker.Hangfire.ProgressFactory

Turns an expected item count into percentage updates for a Hangfire.Console progress bar. Progress state is isolated per async job execution so the singleton service can be used by concurrent jobs.

## Installation

```bash
dotnet add package Soenneker.Hangfire.ProgressFactory
```

## Registration

```csharp
using Soenneker.Hangfire.ProgressFactory.Registrars;

services.AddProgressFactoryAsSingleton();
```

This also registers the Hangfire.Console progress-bar services required by the factory.

## Usage in a job

```csharp
using Soenneker.Hangfire.ProgressFactory.Abstract;

public sealed class ImportJob(IProgressFactory progress)
{
    public async Task Run(IReadOnlyList<ImportItem> items, CancellationToken cancellationToken)
    {
        progress.Init(items.Count);

        foreach (ImportItem item in items)
        {
            await Import(item, cancellationToken);
            progress.Increment();
        }
    }
}
```

Each `Increment()` advances by `100 / count`, caps the reported value at 100, and ignores increments after completion. Initializing with zero items immediately reports 100. Calling `Increment()` before `Init()` throws `InvalidOperationException`.

Initialize once for each job execution. If work is fanned out to parallel tasks within one job, increments share a synchronized progress state.
