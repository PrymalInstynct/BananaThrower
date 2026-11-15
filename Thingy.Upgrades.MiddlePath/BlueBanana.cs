using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Thingy.Displays.Projectiles;

namespace Thingy.Upgrades.MiddlePath;

public class BlueBanana : ModUpgrade<BananaThrower>
{
	public override int Path => 1;

	public override int Tier => 4;

	public override int Cost => 4440;

	public override string DisplayName => "Blue Banana";

	public override string Description => "Moab Hates Blue Banana So Blue Banana Deal 2.5x Damage To Moab-Class Bloon";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "BlueBanana-icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(tower)
			select weaponModel.projectile)
		{
			ProjectileModelBehaviorExt.AddBehavior<DamageModifierForTagModel>(item, new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1f, 25f, false, false));
			ProjectileModelExt.ApplyDisplay<BlueWildCardDisplay>(item);
		}
	}
}
