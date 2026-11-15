using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays.Tier5;

public class TFDisplay : ModTowerDisplay<BananaThrower>
{
	public override string BaseDisplay => GetDisplay(TowerType.SuperMonkey, 3, 0, 0);

	public override float Scale => 1.15f;

	public override bool UseForTower(int[] tiers)
	{
		return tiers[2] == 5;
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		SetMeshTexture(node, "TFDisplay");
	}
}
