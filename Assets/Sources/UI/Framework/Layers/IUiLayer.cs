using System.Collections.Generic;
using Sources.Constants;
using UnityEngine;

namespace Sources.UI.Framework.Layers {
	public interface IUiLayer
	{
		UIConstants.Layer Type { get; }
		GameObject MyGameObject { get; }
		Dictionary<UIConstants.Region, IUiRegion> Regions { get; set; }
		void Initialize();
	}
}
