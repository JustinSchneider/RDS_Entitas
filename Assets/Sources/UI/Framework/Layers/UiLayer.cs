using System.Collections.Generic;
using Sources.Constants;
using UnityEngine;

namespace Sources.UI.Framework.Layers
{
	public class UiLayer : MonoBehaviour, IUiLayer
	{
		[SerializeField] private UIConstants.Layer type;

		public UIConstants.Layer Type => type;
		public GameObject                    MyGameObject { get; private set; }
		public Dictionary<UIConstants.Region, IUiRegion> Regions      { get; set; }

		public void Initialize()
		{
			MyGameObject = gameObject;
			Regions = new Dictionary<UIConstants.Region, IUiRegion>();

			IUiRegion[] regions = gameObject.GetComponentsInChildren<IUiRegion>();
			for (var i = 0; i < regions.Length; i++)
			{
				Regions.Add(regions[i].Type, regions[i]);
				regions[i].Initialize();
			}
		}
	}
}