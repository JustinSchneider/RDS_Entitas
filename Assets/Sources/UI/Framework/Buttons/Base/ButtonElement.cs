using Sources.UI.Framework.Base;
using Sources.UI.Framework.Buttons.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Framework.Buttons.Base {
    abstract class ButtonElement : UiElement, IButtonElement
    {
        private Button unityButton;

        public Button UnityButton => unityButton;

        public override void Initialize()
        {
            base.Initialize();
            unityButton = GetComponentInChildren<Button>();
        }
        
        public override void SetInteractable(bool interactable)
        {
            unityButton.interactable = interactable;
        }

        public override void OnDisable()
        {
            Enabled = false;
        }
    }
}
