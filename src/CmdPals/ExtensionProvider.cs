using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace CmdPals;

public sealed partial class ExtensionProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public ExtensionProvider()
    {
        DisplayName = "CmdPals";
        Icon = IconHelpers.FromRelativePath("Assets\\Palette.png");

        _commands =
        [
            new CommandItem(new Extensions.ProcessKiller()),
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }
}