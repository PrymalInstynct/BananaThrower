using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace Thingy.Upgrades.TopPath;

public class EvenMoreSpeedyDart : ModUpgrade<BananaThrower>
{
	public override int Path => 0;

	public override int Tier => 4;

	public override int Cost => 2700;

	public override string Description => "Throws banana really fast";

	public override string Icon => "EvenMoreSpeedyDart-icon,";

	public override string Portrait => "Thingy-portrait";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			((Model)tower).GetDescendant<DamageModel>().damage = 3f;
			weapon.Rate *= 0.333333f;
			((Model)tower).GetDescendant<ProjectileModel>().pierce = 10f;
		}
	}
}
