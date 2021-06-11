using Sources.UI.Framework.Base;

namespace Sources.UI.Framework.Buttons.Interfaces {
	public interface IButtonElement : IUiElement
	{
		UnityEngine.UI.Button UnityButton { get; }
	}
}