using System.Collections.Generic;
using Sources.Constants;
using UnityEngine;

namespace Sources.UI.Framework.Layers {
	public interface IUiRegion
	{
		UIConstants.Region Type { get; }
		GameObject MyGameObject { get; }
		int MaxOpenMenus { get; }
		List<MenuEntity> CurrentOpenMenus { get; set; }
		void Initialize();
	}
}