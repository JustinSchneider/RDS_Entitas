using Sources.UI.Framework.Base;

namespace Sources.UI.Framework.Toggles.Interfaces {
	public interface IToggleElement : IUiElement
	{
		UnityEngine.UI.Toggle UnityToggle { get; }
	}
}