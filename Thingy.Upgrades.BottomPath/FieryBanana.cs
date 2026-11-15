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

public class FieryBanana : ModUpgrade<BananaThrower>
{
	public override int Path => 2;

	public override int Tier => 4;

	public override int Cost => 2700;

	public override string Description => "Bloon are now set on fire when a banana hit them";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "FieryBanana-icon";

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
				ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 25f, false, false));
				((Model)tower).GetDescendant<DamageModel>().damage = 10f;
				item2.collisionPasses = new int[] { -1, 0 };
				AddBehaviorToBloonModel val = ModelExt.Duplicate<AddBehaviorToBloonModel>(((Model)Game.instance.model.GetTowerFromId("Alchemist")).GetDescendant<AddBehaviorToBloonModel>());
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).interval = 1f / 3f;
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).damage = 2f;
				val.lifespan = 20f;
				val.lifespanFrames = 1200;
				((ProjectileBehaviorWithOverlayModel)val).overlayType = "Fire";
				ProjectileModelBehaviorExt.AddBehavior<AddBehaviorToBloonModel>(item2, val);
			}
		}
	}
}
