using Sources.UI.Framework.Base;
using Sources.UI.Framework.InputFields.Interfaces;
using TMPro;

namespace Sources.UI.Framework.InputFields.Base
{
    abstract class InputFieldElement : UiElement, IInputFieldElement
    {
        private TMP_InputField unityInputField;

        public TMP_InputField UnityInputField => unityInputField;

        public override void Initialize()
        {
            base.Initialize();
            unityInputField = GetComponentInChildren<TMP_InputField>();
        }

        public override void SetInteractable(bool interactable)
        {
            unityInputField.interactable = interactable;
        }
    }
}
