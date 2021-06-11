using Sources.UI.Framework.Base;
using TMPro;

namespace Sources.UI.Framework.Labels.Interfaces {
	public interface ILabelElement : IUiElement
	{
		TMP_Text UnityText { get; }
	}
}