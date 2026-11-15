using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Linq;

namespace Thingy.Upgrades.BottomPath;

public class BananaEyes : ModUpgrade<BananaThrower>
{
	public override int Path => 2;

	public override int Tier => 5;

	public override int Cost => 140000;

	public override string DisplayName => "Banana Eyes";

	public override string Description => "I like banana Omg is that a banana ";

	public override string Portrait => "BananaEyes-portrait";

	public override string Icon => "BananaEyes-icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		AttackModel attackModel = TowerModelExt.GetAttackModel(tower);
		foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(tower)
			select weaponModel.projectile)
		{
			foreach (ProjectileModel item2 in Il2CppSystem.Linq.Enumerable.ToArray<ProjectileModel>(((Model)tower).GetDescendants<ProjectileModel>()))
			{
				ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 4500f, false, false));
				((Model)tower).GetDescendant<DamageModel>().damage = 100f;
				((Model)tower).GetDescendant<ProjectileModel>().pierce = 70f;
				item2.collisionPasses = new int[] { -1, 0 };
				AddBehaviorToBloonModel val = ModelExt.Duplicate<AddBehaviorToBloonModel>(((Model)Game.instance.model.GetTowerFromId("Alchemist")).GetDescendant<AddBehaviorToBloonModel>());
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).interval = 1f / 3f;
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).damage = 15f;
				val.lifespan = 20f;
				val.lifespanFrames = 1200;
				((ProjectileBehaviorWithOverlayModel)val).overlayType = "Fire";
				ProjectileModelBehaviorExt.AddBehavior<AddBehaviorToBloonModel>(item2, val);
				tower.range += 999f;
				AttackModel attackModel2 = TowerModelExt.GetAttackModel(tower);
				attackModel2.range += 999f;
				foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
				{
					weapon.Rate *= 0.333333f;
				}
			}
		}
	}
}
