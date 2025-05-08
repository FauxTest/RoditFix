using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace SamplePlugin;

public sealed class Plugin : IDalamudPlugin
{
    private const string CommandName = "/pmycommand";

    public Configuration Configuration { get; init; }

    public Plugin()
    {
        Configuration = Services.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

        _ = Services.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "A useful message to display in /xlhelp"
        });

        // This adds a button to the plugin installer entry of this plugin which allows
        // to toggle the display status of the configuration ui
        //PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;

        // Adds another button that is doing the same but for the main ui of the plugin
        //PluginInterface.UiBuilder.OpenMainUi += ToggleMainUI;
    }

    public void Dispose()
    {
        bool successfulDispose = true;

        #region Dispose Actions
        // Verify each dispose action with the successfulDispose variable.
        successfulDispose &= Services.CommandManager.RemoveHandler(CommandName);
        #endregion

        if (!successfulDispose) {
            
        }
    }

    private void OnCommand(string command, string args)
    {
        
    }
}
