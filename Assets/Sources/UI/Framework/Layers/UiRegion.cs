using System.Collections.Generic;
using Sources.Constants;
using UnityEngine;

namespace Sources.UI.Framework.Layers {
	public class UiRegion : MonoBehaviour, IUiRegion
	{
		[SerializeField] private UIConstants.Region type;
		[SerializeField] private int maxOpenMenus = 1;
		public int MaxOpenMenus => maxOpenMenus;

		public UIConstants.Region Type => type;
		public GameObject MyGameObject { get; private set; }
		public List<MenuEntity> CurrentOpenMenus { get; set; }

		public void Initialize()
		{
			GameObject o = gameObject;
			MyGameObject = o;
			CurrentOpenMenus = new List<MenuEntity>();
			gameObject.SetActive(false);	// Regions are deactivated by default and get activated when they have an active menu
		}
	}
}
