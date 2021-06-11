using Sources.UI.Framework.Base;
using TMPro;

namespace Sources.UI.Framework.InputFields.Interfaces {
	public interface IInputFieldElement : IUiElement
	{
		TMP_InputField UnityInputField { get; }
	}
}