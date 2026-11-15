using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;

namespace Thingy.Displays.Tier5;

public class AceOfSpadesDisplay : ModTowerDisplay<BananaThrower>
{
	public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 5, 0, 0);

	public override bool UseForTower(int[] tiers)
	{
		return tiers[1] == 5;
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		UnityDisplayNodeExt.SaveMeshTexture(node, 1, (string)null);
		UnityDisplayNodeExt.SaveMeshTexture(node, 2, (string)null);
		UnityDisplayNodeExt.SaveMeshTexture(node, 0, (string)null);
		UnityDisplayNodeExt.PrintInfo(node);
		UnityDisplayNodeExt.RemoveBone(node, "SuperMonkeyRig:Dart", false);
		SetMeshTexture(node, "AceOfSpadesCape", 1);
		SetMeshOutlineColor(node, new Color(0f, 0f, 0f), 1);
		SetMeshTexture(node, "AceOfSpadesDisplay", 2);
		SetMeshOutlineColor(node, new Color(0f, 0f, 0f), 2);
	}
}
