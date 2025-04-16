using System.Diagnostics;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace CmdPals.Commands;

public sealed partial class KillProcessCommand : InvokableCommand
{
    private readonly Process _process;

    public override IconInfo Icon => new("\uE8A7");
    public override string Name => "Kill Process";

    public KillProcessCommand(Process process)
    {
        _process = process;
    }

    public override ICommandResult Invoke()
    {
        _process.Kill();
        return CommandResult.Hide();
    }
}