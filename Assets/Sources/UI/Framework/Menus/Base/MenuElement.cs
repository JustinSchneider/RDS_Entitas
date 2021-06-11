using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Constants;
using Sources.UI.Framework.Base;
using Sources.UI.Framework.Layers;
using Sources.UI.Framework.Menus.Interfaces;
using UnityEngine;

namespace Sources.UI.Framework.Menus.Base
{
	abstract class MenuElement : UiElement, IMenuElement
	{
		public Contexts Contexts { get; set; }
		public Dictionary<string, IUiElement> ChildElements { get; set; }

		public override void Initialize()
		{
			base.Initialize();
			Contexts = Contexts.sharedInstance;
			ChildElements = new Dictionary<string, IUiElement>();
			SetupChildElements();
		}

		private void SetupChildElements()
		{
			IUiElement[] uiElements = gameObject.GetComponentsInChildren<IUiElement>(true);
			
			foreach (IUiElement uiElement in uiElements)
			{
				if (uiElement.GameObject == gameObject) continue; // Make sure we aren't selecting the parent object
				
				uiElement.Initialize();
				ChildElements.Add(uiElement.Id, uiElement);
			}
		}
		
		/// <summary>
		/// Set a UI element as interactable or not
		/// </summary>
		/// <param name="state"></param>
		/// <param name="id">If there's an ID, it will only set that one, if not
		/// it will set all of them</param>
		public void SetInteractable(bool state, string id = null)
		{
			if (id != null)
				ChildElements[id].SetInteractable(state);
			else
			{
				foreach (KeyValuePair<string, IUiElement> keyValuePair in ChildElements)
				{
					keyValuePair.Value.SetInteractable(state);
				}
			}
		}
	}
}
