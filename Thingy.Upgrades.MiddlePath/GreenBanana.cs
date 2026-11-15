using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Thingy.Displays.Projectiles;

namespace Thingy.Upgrades.MiddlePath;

public class GreenBanana : ModUpgrade<BananaThrower>
{
	public override int Path => 1;

	public override int Tier => 3;

	public override int Cost => 1870;

	public override string DisplayName => "GreenBanana";

	public override string Description => "Green Banana Deal Way More Damage To Bloon";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "GreenBanana-icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			((Model)tower).GetDescendant<DamageModel>().damage = 10f;
			((Model)tower).GetDescendant<ProjectileModel>().pierce = 11f;
			ProjectileModelExt.ApplyDisplay<BlueCardDisplay>(weapon.projectile);
		}
	}
}
