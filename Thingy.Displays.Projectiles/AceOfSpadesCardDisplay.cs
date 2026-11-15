using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;

namespace Thingy.Displays.Projectiles;

public class AceOfSpadesCardDisplay : ModDisplay
{
	public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";

	public override void ModifyDisplayNode(UnityDisplayNode node)
	{
		Set2DTexture(node, ((ModContent)this).Name);
	}
}
