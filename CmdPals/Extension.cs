using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CommandPalette.Extensions;

namespace CmdPals;

[Guid("981b06af-d575-43e3-b1b7-e47aab1fced7")]
public sealed partial class Extension : IExtension, IDisposable
{
    private readonly ManualResetEvent _disposeEvent;

    private readonly ExtensionProvider _provider = new();

    public Extension(ManualResetEvent disposeEvent)
    {
        this._disposeEvent = disposeEvent;
    }

    public object? GetProvider(ProviderType providerType)
    {
        return providerType switch
        {
            ProviderType.Commands => _provider,
            _ => null,
        };
    }

    public void Dispose() => _disposeEvent.Set();
}