using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace Thingy.Upgrades.MiddlePath;

public class StrongerBanana : ModUpgrade<BananaThrower>
{
	public override int Path => 1;

	public override int Tier => 1;

	public override int Cost => 400;

	public override string DisplayName => "Stronger Banana";

	public override string Description => "Banana have increased pierce and damage";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "StrongerBanana-icon";

	public override void ApplyUpgrade(TowerModel tower)
	{
		((Model)tower).GetDescendant<DamageModel>().damage = 2f;
		((Model)tower).GetDescendant<ProjectileModel>().pierce = 4f;
	}
}
