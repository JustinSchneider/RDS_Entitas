using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.UI.Framework.Menus.Interfaces;

[Menu]
public class MenuComponent : IComponent
{
	[PrimaryEntityIndex]
	public IMenuElement Value;
}
