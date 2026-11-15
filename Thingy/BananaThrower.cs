using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Thingy.Displays.Projectiles;

namespace Thingy;

public class BananaThrower : ModTower
{
	public override TowerSet TowerSet => (TowerSet)1;

	public override string BaseTower => TowerType.DartMonkey;

	public override int Cost => 400;

	public override int TopPathUpgrades => 5;

	public override int MiddlePathUpgrades => 5;

	public override int BottomPathUpgrades => 5;

	public override string Description => "Banana Thrower";

	public override string Icon => "Thingy-icon,";

	public override string Portrait => "Thingy-portrait";

	public override ParagonMode ParagonMode => (ParagonMode)2;

	public override void ModifyBaseTowerModel(TowerModel towerModel)
	{
		towerModel.range += 10f;
		AttackModel attackModel = TowerModelExt.GetAttackModel(towerModel);
		attackModel.range += 10f;
		ProjectileModel projectile = ((Il2CppArrayBase<WeaponModel>)(object)attackModel.weapons)[0].projectile;
		ProjectileModelExt.ApplyDisplay<RedCardDisplay>(projectile);
		projectile.pierce += 4f;
	}

	public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
	{
		return towerSet.First((TowerDetailsModel model) => model.towerId == TowerType.BoomerangMonkey).towerIndex + 1;
	}

	public override bool IsValidCrosspath(int[] tiers)
	{
		return ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
	}
}
