using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;

namespace Thingy.Upgrades.MiddlePath;

public class BananaTerror : ModUpgrade<BananaThrower>
{
	public override int Path => 1;

	public override int Tier => 5;

	public override int Cost => 98000;

	public override int Priority => -3;

	public override string DisplayName => "Banana Terror";

	public override string Description => "Ability : Eradicate all bloon in range beside bad";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "ExplodingBanana-icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(tower)
			select weaponModel.projectile)
		{
			ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 4500f, false, false));
			tower.range += 20f;
			AttackModel attackModel = TowerModelExt.GetAttackModel(tower);
			attackModel.range += 20f;
			ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 1400f, false, false));
			((Model)tower).GetDescendant<DamageModel>().damage = 70f;
			((Model)tower).GetDescendant<ProjectileModel>().pierce = 40f;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, TowerModelExt.GetAbility(Game.instance.model.GetTowerFromId("SuperMonkey-050")));
			foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
			{
				weapon.Rate *= 0.333333f;
			}
		}
	}
}
