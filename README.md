# Sulexa.CancellationTokenInjection [![CI](https://github.com/Sulexa/Sulexa.CancellationTokenInjection/actions/workflows/CICD.yml/badge.svg?branch=main)](https://github.com/Sulexa/Sulexa.CancellationTokenInjection/actions/workflows/CICD.yml) [![Nuget](https://img.shields.io/nuget/v/Sulexa.CancellationTokenInjection.svg?style=flat)](https://www.nuget.org/packages/Sulexa.CancellationTokenInjection) [![codecov](https://codecov.io/gh/Sulexa/Sulexa.CancellationTokenInjection/branch/main/graph/badge.svg?token=4WQL6WPC4F)](https://codecov.io/gh/Sulexa/Sulexa.CancellationTokenInjection)

A small library to handle injection of cancellation token.
Cancellation token are a way to stop asynchronous call.

## Usage

In startup add services.AddHttpContextCancellationTokenInjection(); in the ConfigureServices method:

```csharp
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpContextCancellationTokenInjection();
}
```
Then you can inject CancellationTokenBase in your classes:
```csharp
private readonly CancellationTokenBase _cancellationTokenBase;

public MyClass(CancellationTokenBase cancellationTokenBase)
{
    this._cancellationTokenBase = cancellationTokenBase;
}
```

## Example

In the following case we have an api which wait 10s before returning a result.
```csharp
[HttpGet("TestCancellationAsync")]
public async Task<ActionResult<string>> TestCancellationAsync()
{
    await Task.Delay(10000);
    return Ok("Finished without cancellation");
}
```
If i were to call the api and cancel the call (leave the webpage, cancel the httpRequest...)  
The server would continue waiting until the end and wait the 10s.

But if i choose to use my cancellation token
```csharp
private readonly CancellationTokenBase _cancellationTokenBase;

public CancellationTokenTestController(CancellationTokenBase cancellationTokenBase)
{
    this._cancellationTokenBase = cancellationTokenBase;
}

[HttpGet("TestCancellationAsync")]
public async Task<ActionResult<string>> TestCancellationAsync()
{
    await Task.Delay(10000, _cancellationTokenBase);
    return Ok("Finished without cancellation");
}
```
If i were to call the api and cancel the call, the Delay will stop immediately throwing an exception.

If you use entity framework core for exemple you can use cancellation token on database call (ToList(cancellationTokenBase)).
It could be a great improvement on search api which are sometime called before the previous is finished.
