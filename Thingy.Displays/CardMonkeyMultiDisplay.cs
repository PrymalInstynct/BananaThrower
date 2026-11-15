using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays;

public class CardMonkeyMultiDisplay : ModTowerDisplay<BananaThrower>
{
	private readonly int[] t = null;

	public override string Name => "CardMonkeyMultiDisplay-" + ArrayExt.Printed(t);

	public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, t[0], t[1], t[2]);

	public CardMonkeyMultiDisplay()
	{
	}

	public CardMonkeyMultiDisplay(int[] tiers)
	{
		t = tiers;
	}

	public override IEnumerable<ModContent> Load()
	{
		for (int i = 0; i <= 2; i++)
		{
			for (int j = 0; j <= 2; j++)
			{
				for (int k = 0; k <= 2; k++)
				{
					int[] tiers = new int[3] { i, j, k };
					if (ArrayExt.IsValid(tiers))
					{
						yield return (ModContent)(object)new CardMonkeyMultiDisplay(tiers);
					}
				}
			}
		}
	}

	public override bool UseForTower(int[] tiers)
	{
		if (t.Sum() == 0)
		{
			return tiers.Max() < 5;
		}
		return false;
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		UnityDisplayNodeExt.PrintInfo(node);
		UnityDisplayNodeExt.SaveMeshTexture(node, 0, (string)null);
		SetMeshTexture(node, "CardMonkeyBaseDisplay");
		UnityDisplayNodeExt.RemoveBone(node, "SuperMonkeyRig:Dart", false);
	}
}
