using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays.Tier5;

public class RoyalFlushDisplay : ModTowerDisplay<BananaThrower>
{
	public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 0, 5, 0);

	public override bool UseForTower(int[] tiers)
	{
		return tiers[0] == 5;
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		UnityDisplayNodeExt.PrintInfo(node);
		SetMeshTexture(node, "RoyalFlushDisplay");
	}
}
