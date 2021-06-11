using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.UI.Framework.Menus.Base;

[Menu]
public class MenuAddressComponent : IComponent
{
	[PrimaryEntityIndex]
	public string Value;
}
