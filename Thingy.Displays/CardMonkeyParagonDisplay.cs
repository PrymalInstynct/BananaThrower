using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;

namespace Thingy.Displays;

public class CardMonkeyParagonDisplay : ModTowerDisplay<BananaThrower>
{
	public override float Scale => 0.75f + (float)ParagonDisplayIndex * 0.025f;

	public override string BaseDisplay => AttackModelBehaviorExt.GetBehavior<DisplayModel>(TowerModelExt.GetAttackModel(Game.instance.model.GetTower(TowerType.SuperMonkey, 5, 0, 0))).display.guidRef;

	public override int ParagonDisplayIndex { get; }

	public override string Name => "CardMonkeyParagonDisplay" + ParagonDisplayIndex;

	public CardMonkeyParagonDisplay()
	{
	}

	public CardMonkeyParagonDisplay(int i)
	{
		ParagonDisplayIndex = i;
	}

	public override bool UseForTower(int[] tiers)
	{
		return IsParagon(tiers);
	}

	public override IEnumerable<ModContent> Load()
	{
		for (int i = 0; i < 5; i++)
		{
			yield return (ModContent)(object)new CardMonkeyParagonDisplay(i);
		}
	}

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		UnityDisplayNodeExt.PrintInfo(node);
		UnityDisplayNodeExt.SaveMeshTexture(node, 0, (string)null);
		SetMeshTexture(node, "CardMonkeyParagonDisplay");
		SetMeshOutlineColor(node, new Color(16f / 85f, 0f, 0.4745098f));
	}
}
