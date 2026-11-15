using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Thingy.Displays.Projectiles;

namespace Thingy.Upgrades.TopPath;

public class SonicDart : ModUpgrade<BananaThrower>
{
	public override int Path => 0;

	public override int Tier => 5;

	public override int Cost => 130000;

	public override int Priority => -2;

	public override string Description => "Thorws Banana so fast that they become orange since they on fire!";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "SonicDart-icon,";

	public override void ApplyUpgrade(TowerModel tower)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		tower.range += 10f;
		AttackModel attackModel = TowerModelExt.GetAttackModel(tower);
		attackModel.range += 10f;
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(tower)
				select weaponModel.projectile)
			{
				ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 450f, false, false));
				((Model)tower).GetDescendant<DamageModel>().damage = 80f;
				weapon.Rate *= 0.111111f;
				((Model)tower).GetDescendant<ProjectileModel>().pierce = 30f;
				ProjectileModelExt.ApplyDisplay<RedWildCardDisplay>(weapon.projectile);
			}
		}
	}
}
