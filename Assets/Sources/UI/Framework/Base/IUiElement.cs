using UnityEngine;

namespace Sources.UI.Framework.Base {
	public interface IUiElement
	{
		string Id { get; }
		bool Enabled { get; }
		GameObject GameObject { get; }
		void SetInteractable(bool state);
		void Initialize();
		void SetId(string newId);
	}
}
