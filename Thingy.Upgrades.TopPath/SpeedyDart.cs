using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace Thingy.Upgrades.TopPath;

public class SpeedyDart : ModUpgrade<BananaThrower>
{
	public override int Path => 0;

	public override int Tier => 3;

	public override int Cost => 1200;

	public override string Description => "Throws banana way faster";

	public override string Icon => "SpeedyDart-icon,";

	public override string Portrait => "Thingy-portrait";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			((Model)tower).GetDescendant<DamageModel>().damage = 3f;
			weapon.Rate *= 0.444444f;
		}
	}
}
