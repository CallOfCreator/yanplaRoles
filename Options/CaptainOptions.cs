using MiraAPI.GameOptions;
using MiraAPI.Utilities;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using UnityEngine;

namespace yanplaRoles.Options.Modifiers;

public class ModifierOptions : AbstractOptionGroup
{ 
    public override string GroupName => "Modifiers";
    public override Color GroupColor => new Color32(255, 215, 0, byte.MaxValue);
        
    [ModdedNumberOption("Captain Chance", min: 0, max: 100, 10f, MiraNumberSuffixes.Percent)]
    public float CaptainChance { get; set; } = 100f;
}