using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Constants;

[Meta][Unique][Event(EventTarget.Any)]
public class InteractionModeComponent : IComponent
{
	public ProjectConstants.InteractionMode Value;
	
}