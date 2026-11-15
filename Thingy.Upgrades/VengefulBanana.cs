using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.IO;

namespace Thingy.Upgrades;

public class VengefulBanana : ModParagonUpgrade<BananaThrower>
{
	public override int Cost => 2140000;

	public override string Description => "The True Power Of Banana...";

	public override string DisplayName => "Vengeful Banana";

	public override string Icon => "GodKingOfSpades-Icon";

	public override string Portrait => "GodKingOfSpades-Portrait";

	public override void ApplyUpgrade(TowerModel towerModel)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		AttackModel attackModel = TowerModelExt.GetAttackModel(towerModel);
		foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(towerModel)
			select weaponModel.projectile)
		{
			foreach (ProjectileModel item2 in MonoLinqHelper.ToArray<ProjectileModel>(((Model)towerModel).GetDescendants<ProjectileModel>()))
			{
				TowerModelBehaviorExt.AddBehavior<AbilityModel>(towerModel, TowerModelExt.GetAbility(Game.instance.model.GetTowerFromId("SuperMonkey-050")));
				ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 87500f, false, false));
				TowerModelExt.GetWeapon(towerModel).emission = (EmissionModel)new ArcEmissionModel("ArcEmissionModel_", 3, 0f, 20f, (Il2CppReferenceArray<EmissionBehaviorModel>)null, false, false);
				((Model)towerModel).GetDescendant<DamageModel>().damage = 87500f;
				item2.collisionPasses = new int[] { -1, 0 };
				AddBehaviorToBloonModel val = ModelExt.Duplicate<AddBehaviorToBloonModel>(((Model)Game.instance.model.GetTowerFromId("Alchemist")).GetDescendant<AddBehaviorToBloonModel>());
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).interval = 1f / 3f;
				AddBehaviorToBloonModelExt.GetBehavior<DamageOverTimeModel>(val).damage = 200f;
				val.lifespan = 20f;
				val.lifespanFrames = 1200;
				((ProjectileBehaviorWithOverlayModel)val).overlayType = "Fire";
				ProjectileModelBehaviorExt.AddBehavior<AddBehaviorToBloonModel>(item2, val);
			}
		}
	}
}
