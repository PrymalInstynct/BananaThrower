using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace Thingy.Upgrades.BottomPath;

public class IncreasedRange : ModUpgrade<BananaThrower>
{
	public override int Path => 2;

	public override int Tier => 1;

	public override int Cost => 300;

	public override string Description => "Increased Range!";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "MoreRange-icon,";

	public override void ApplyUpgrade(TowerModel tower)
	{
		tower.range += 10f;
		AttackModel attackModel = TowerModelExt.GetAttackModel(tower);
		attackModel.range += 10f;
	}
}
