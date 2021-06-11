using Sources.UI.Framework.Base;
using Sources.UI.Framework.Toggles.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Framework.Buttons.Base {
    abstract class ToggleElement : UiElement, IToggleElement
    {
        private Toggle unityToggle;

        public Toggle UnityToggle => unityToggle;

        public override void Initialize()
        {
            base.Initialize();
            unityToggle = GetComponentInChildren<Toggle>();
        }
        
        public override void SetInteractable(bool interactable)
        {
            unityToggle.interactable = interactable;
        }
    }
}
