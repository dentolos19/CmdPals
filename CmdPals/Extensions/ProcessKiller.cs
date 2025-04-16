using CmdPals.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CmdPals.Extensions;

internal sealed partial class ProcessKiller : ListPage
{
    public ProcessKiller()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        Title = "Process Killer";
        Name = "Process Killer";
    }

    public override IListItem[] GetItems()
    {
        var processes = Process.GetProcesses();
        var items = new List<ListItem>();

        foreach (var process in processes)
        {
            // Hide those processes that does not have an interactive window.
            if (process.MainWindowHandle == IntPtr.Zero)
                continue;

            // Add item corresponding to the process with a kill command.
            var item = new ListItem(new KillProcessCommand(process))
            {
                Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png"),
                Title = process.ProcessName,
                Subtitle = process.MainWindowTitle
            };

            items.Add(item);
        }

        return items.ToArray();
    }
}