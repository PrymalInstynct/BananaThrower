using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace Thingy.Upgrades.TopPath;

public class FasterThrowing : ModUpgrade<BananaThrower>
{
	public override int Path => 0;

	public override int Tier => 1;

	public override int Cost => 300;

	public override string Description => "Throws banana faster";

	public override string Icon => "FasterThrowing-icon,";

	public override string Portrait => "Thingy-portrait";

	public override void ApplyUpgrade(TowerModel tower)
	{
		foreach (WeaponModel weapon in TowerModelExt.GetWeapons(tower))
		{
			weapon.Rate *= 0.666666f;
		}
	}
}
