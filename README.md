[![](https://img.shields.io/nuget/v/Soenneker.Hangfire.ProgressFactory.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ProgressFactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.progressfactory/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.progressfactory/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Hangfire.ProgressFactory.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Hangfire.ProgressFactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.hangfire.progressfactory/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.hangfire.progressfactory/actions/workflows/codeql.yml)

# Soenneker.Hangfire.ProgressFactory

Provides additional functionality around the Hangfire progress tools.

## Install

```bash
dotnet add package Soenneker.Hangfire.ProgressFactory
```

## Quick start

```csharp
using Soenneker.Hangfire.ProgressFactory.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddProgressFactoryAsSingleton();
```

Adds `IProgressFactory` as a singleton service.

## What you get

- `IProgressFactory` — Provides additional functionality around the Hangfire progress tools.
- `ProgressFactoryRegistrar` — Provides additional functionality around the Hangfire progress tools.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ProgressFactoryRegistrar.AddProgressFactoryAsSingleton(services)` | Adds `IProgressFactory` as a singleton service. | The same service collection, so additional registrations can be chained. |
