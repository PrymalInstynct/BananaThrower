using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays.Projectiles;

public class AceOfSpadesAbilityDisplay : ModDisplay
{
	public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";

	public override float Scale => 2f;

	public override Vector3 PositionOffset => new Vector3(0f, 5f, 0f);

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		Set2DTexture(node, "AceOfSpadesCardDisplay");
	}
}
