using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace CmdPals;

public sealed partial class ExtensionProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public ExtensionProvider()
    {
        DisplayName = "CmdPals";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");

        _commands =
        [
            new CommandItem(new Extensions.ProcessKiller()) { Title = "Kill Process" },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }
}