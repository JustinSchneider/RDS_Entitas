using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
public class MenuIdComponent : IComponent
{
	[PrimaryEntityIndex]
	public string Value;
}
