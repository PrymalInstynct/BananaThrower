using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays;

public class CardMonkeyBaseDisplay : ModTowerDisplay<BananaThrower>
{
	public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 0, 0, 0);

	public override bool UseForTower(int[] tiers)
	{
		return tiers.Sum() == 0;
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		UnityDisplayNodeExt.PrintInfo(node);
		UnityDisplayNodeExt.SaveMeshTexture(node, 0, (string)null);
		SetMeshTexture(node, ((ModContent)this).Name);
		UnityDisplayNodeExt.RemoveBone(node, "SuperMonkeyRig:Dart", false);
	}
}
