using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Constants;

[Menu]
public class MenuTypeComponent : IComponent
{
	[PrimaryEntityIndex]
	public UIConstants.Menu Value;
}
