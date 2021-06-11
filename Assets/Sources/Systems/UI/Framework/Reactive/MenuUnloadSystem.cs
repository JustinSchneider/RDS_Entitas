using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Sources.Constants;
using Sources.UI.Framework.Layers;
using Sources.UI.Framework.Menus.Interfaces;
using UnityEngine;

namespace Sources.Systems.UI.Framework.Reactive
{
	public class MenuUnloadSystem : ReactiveSystem<MenuEntity>
	{
		private readonly UiContext uiContext;
		public MenuUnloadSystem(Contexts contexts) : base(contexts.menu)
		{
			this.uiContext = contexts.ui;
		}
		
		protected override ICollector<MenuEntity> GetTrigger(IContext<MenuEntity> context)
		{
			return context.CreateCollector(MenuMatcher.LoadMenu.Removed());
		}

		protected override bool Filter(MenuEntity entity)
		{
			return !entity.isLoadMenu;
		}

		protected override void Execute(List<MenuEntity> entities)
		{
			foreach (MenuEntity menuEntity in entities.Where(menuEntity => menuEntity.hasView))
			{
				IUiRegion region = uiContext.GetEntityWithLayerType(menuEntity.layerType.Value).layer.Value.Regions.FirstOrDefault(x => x.Key == menuEntity.regionType.Value).Value;
				
				for (int i = region.CurrentOpenMenus.Count - 1; i >= 0; i--)
				{
					if (menuEntity == region.CurrentOpenMenus[i])
					{
						region.CurrentOpenMenus.RemoveAt(i);
					}
				}
				
				if (menuEntity.loadMode.Value == UIConstants.LoadMode.DontUnload)
				{
					menuEntity.view.Value.SetActive(false);
					menuEntity.isLoaded = false;
				}
				else
				{
					menuEntity.isLoaded = false;
					Object.Destroy(menuEntity.view.Value);
					menuEntity.view.Value.Unlink();
					
					menuEntity.RemoveView();
					menuEntity.RemoveMenu();
					menuEntity.RemoveMenuPrefab();
				}

				if (region.CurrentOpenMenus.Count == 0)
				{
					region.MyGameObject.SetActive(false);
				}
			}
		}
	}
}