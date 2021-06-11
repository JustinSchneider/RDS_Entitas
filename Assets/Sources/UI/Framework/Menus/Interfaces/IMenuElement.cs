using System.Collections.Generic;
using Sources.Constants;
using Sources.UI.Framework.Base;
using Sources.UI.Framework.Layers;

namespace Sources.UI.Framework.Menus.Interfaces {
	public interface IMenuElement : IUiElement
	{
		Contexts                       Contexts      { set; }
		Dictionary<string, IUiElement> ChildElements { get; set; }
		void OnEnable();
		void OnDisable();
		void SetInteractable(bool state, string id = null);
	}
}