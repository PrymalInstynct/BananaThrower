using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace Thingy.Upgrades.TopPath;

public class EvenFasterThrowing : ModUpgrade<BananaThrower>
{
	public override int Path => 0;

	public override int Tier => 2;

	public override int Cost => 600;

	public override string Description => "Throws banana even faster";

	public override string Icon => "EvenFasterThorwing-icon,";

	public override string Portrait => "Thingy-portrait";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			((Model)tower).GetDescendant<DamageModel>().damage = 2f;
			weapon.Rate *= 0.555555f;
		}
	}
}
