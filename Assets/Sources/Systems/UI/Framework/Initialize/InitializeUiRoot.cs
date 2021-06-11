using System.Collections.Generic;
using Entitas;
using Sources.Constants;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Sources.Systems.UI.Framework.Initialize
{
	public class InitializeUiRoot : IInitializeSystem
	{
		private readonly UiContext uiContext;
		private readonly Contexts contexts;
		private readonly List<RectTransform> menus;

		public InitializeUiRoot(Contexts contexts)
		{
			this.contexts  = contexts;
		}

		public void Initialize()
		{
			Addressables.InstantiateAsync(UIConstants.UiRootPath).Completed += OnUiRootCreated;
		}

		private void OnUiRootCreated(AsyncOperationHandle<GameObject> uiRoot)
		{
			
			contexts.ui.ReplaceUiRoot(uiRoot.Result);
			
#if UNITY_IOS
			uiRoot.Result.GetComponentInChildren<CanvasScaler>().scaleFactor = 4F;	
#endif
		}
	}
}