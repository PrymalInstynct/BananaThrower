using System;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;

namespace Thingy.Upgrades.BottomPath;

public class CamoSense : ModUpgrade<BananaThrower>
{
	public override int Path => 2;

	public override int Tier => 2;

	public override int Cost => 350;

	public override string DisplayName => "Camo Sense";

	public override string Description => "Banana Thrower Unlocked Ultra-Vision";

	public override string Portrait => "Thingy-Portrait";

	public override string Icon => "CamoDart-Icon";

	public override int Priority => -1;

	public override void ApplyUpgrade(TowerModel tower)
	{
		Il2CppGenericIEnumerable.ForEach<FilterInvisibleModel>(((Model)tower).GetDescendants<FilterInvisibleModel>(), (Action<FilterInvisibleModel>)delegate(FilterInvisibleModel model)
		{
			model.isActive = false;
		});
	}
}
