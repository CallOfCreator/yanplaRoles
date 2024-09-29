using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using UnityEngine;
using MiraAPI.Modifiers.Types;
using yanplaRoles.Options.Modifiers;
using yanplaRoles.CustomGameOverReasons;
using yanplaRoles.Roles;
using MiraAPI.Roles;

namespace yanplaRoles.Modifiers;

[RegisterModifier]
public class ExecutionerTarget : GameModifier
{
    public override string ModifierName => "Executioner Target";
    public override bool HideOnUi => true;
    public override bool IsModifierValidOn(RoleBehaviour role)
    {
        return role.TeamType == RoleTeamTypes.Crewmate;
    }

    public override int GetAmountPerGame()
    {
        return 1;
    }

    public override int GetAssignmentChance()
    {
        return 100;
    }

    public override void OnDeath(DeathReason reason)
    {
        PlayerControl executioner = null;

        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player.Data.Role is Executioner)
            {
                executioner = player;
                break;
            }
        }

        if (executioner != null)
        {
            var roleManager = RoleManager.Instance;
            roleManager.SetRole(executioner, AmongUs.GameOptions.RoleTypes.Crewmate);
            PlayerControl.AllPlayerControls.ForEach((System.Action<PlayerControl>)PlayerNameColor.Set);

            if (reason == DeathReason.Exile)
            {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReasonsEnum.ExecutionerWin, false);
            }
        }
    }


}