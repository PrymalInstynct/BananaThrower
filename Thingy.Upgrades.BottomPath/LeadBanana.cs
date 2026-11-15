using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Thingy.Displays.Projectiles;

namespace Thingy.Upgrades.BottomPath;

public class LeadBanana : ModUpgrade<BananaThrower>
{
	public override int Path => 2;

	public override int Tier => 3;

	public override int Cost => 750;

	public override string Description => "Lead? Uh Fine Im Upgrading My Banana";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "LeadDart-Icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			foreach (ProjectileModel item in from weaponModel in TowerModelExt.GetWeapons(tower)
				select weaponModel.projectile)
			{
				((Model)tower).GetDescendant<DamageModel>().damage = 3f;
				ProjectileModelExt.GetDamageModel(weapon.projectile).immuneBloonProperties = (BloonProperties)0;
				ProjectileModelExt.ApplyDisplay<AceOfSpadesCardDisplay>(item);
			}
		}
	}
}
