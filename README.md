# Sulexa.CancellationTokenInjection [![CI](https://github.com/Sulexa/Sulexa.CancellationTokenInjection/actions/workflows/CICD.yml/badge.svg?branch=main)](https://github.com/Sulexa/Sulexa.CancellationTokenInjection/actions/workflows/CICD.yml) [![Nuget](https://img.shields.io/nuget/v/Sulexa.CancellationTokenInjection.svg?style=flat)](https://www.nuget.org/packages/Sulexa.CancellationTokenInjection) [![GitHub last commit](https://img.shields.io/github/last-commit/Sulexa/Sulexa.CancellationTokenInjection.svg?style=flat)](https://github.com/Sulexa/Sulexa.CancellationTokenInjection/commits/main)

A small library to handle injection of cancellation token.
Cancellation token are a way to stop asynchronous call.

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
private readonly CancellationTokenBase cancellationTokenBase;

public CancellationTokenTestController(CancellationTokenBase cancellationTokenBase)
{
    this.cancellationTokenBase = cancellationTokenBase;
}

[HttpGet("TestCancellationAsync")]
public async Task<ActionResult<string>> TestCancellationAsync()
{
  await Task.Delay(10000, cancellationTokenBase);
  return Ok("Finished without cancellation");
}
```
If i were to call the api and cancel the call, the Delay will stop immediately throwing an exception.

If you use entity framework core for exemple you can use cancellation token on database call (ToList(cancellationTokenBase)).
It could be a great improvement on search api which are sometime called before the previous is finished.
