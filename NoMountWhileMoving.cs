using Dalamud.Game.ClientState.Conditions;
using Dalamud.Plugin;
using ECommons.DalamudServices;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace NoMountWhileMoving;

public sealed class NoMountPlugin : IDalamudPlugin
{
    public string Name => "No Mount While Moving";

    public void Initialize(DalamudPluginInterface pluginInterface)
    {
        Svc.Condition.ConditionChange += PreventMountAction;
    }

    public void Dispose()
    {
        Svc.Condition.ConditionChange -= PreventMountAction;
    }

    private void PreventMountAction(ConditionFlag flag, bool value)
    {
        // Only intervene if the player is attempting to cast a mount action
        if (flag == ConditionFlag.Mounting && value && IsMoving())
        {
            ActionManager.Instance()->CancelAction(); 
        }
    }

    private bool IsMoving()
    {
        var player = Svc.ClientState.LocalPlayer;
        if (player == null) return false; // Player not loaded

        return player.Position != player.PreviousPosition; 
    }
}
