using ECommons;
using ECommons.GameHelpers;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using Lumina.Excel.Sheets;
using Splatoon.SplatoonScripting;
using System.Collections.Generic;

namespace SplatoonScriptsOfficial.Generic;
public class NoMountWhileMoving : SplatoonScript
{
    public override HashSet<uint> ValidTerritories => [];
    public override Metadata? Metadata => new(1, "croizat");

    public override void OnStartingCast(uint source, uint castId)
    {
        if (Player.Object.EntityId == source && IsCastMount(castId) && Player.IsMoving)
            UIState.Instance()->Hotbar.CancelCast();
    }

    private bool IsCastMount(uint castId) => GenericHelpers.GetRow<Action>(castId) is { ActionCategory.RowId: 12 };
}
