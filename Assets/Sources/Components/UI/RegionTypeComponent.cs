using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Constants;

namespace Sources.Components.UI {
	[Menu, Ui]
	public class RegionTypeComponent : IComponent
	{
		public UIConstants.Region Value;
	}
}