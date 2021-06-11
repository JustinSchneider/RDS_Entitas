using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Sources.Constants;
using Sources.UI.Framework.Layers;
using Sources.UI.Framework.Menus.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sources.Systems.UI.Framework.Reactive
{
	public class MenuLoadSystem : ReactiveSystem<MenuEntity>
	{
		private readonly UiContext uiContext;
		private readonly MenuContext menuContext;

		public MenuLoadSystem(Contexts contexts) : base(contexts.menu)
		{
			this.uiContext = contexts.ui;
			this.menuContext = contexts.menu;
		}
		
		protected override ICollector<MenuEntity> GetTrigger(IContext<MenuEntity> context)
		{
			return context.CreateCollector(MenuMatcher.LoadMenu.Added());
		}

		protected override bool Filter(MenuEntity entity)
		{
			return entity.isLoadMenu;
		}

		protected override void Execute(List<MenuEntity> entities)
		{
			foreach (MenuEntity menuEntity in entities)
			{
				if (menuEntity.hasView)
				{
					if (menuEntity.view.Value.activeSelf)
					{
						Debug.LogWarning("You're trying to activate a menu that is already active");
						return;
					}
					
					Debug.Assert(menuEntity.loadMode.Value == UIConstants.LoadMode.DontUnload);
					CheckOpenMenus(menuEntity);
					menuEntity.view.Value.SetActive(true);
					menuEntity.isLoaded = true;
					return;
				}
				
				Addressables.LoadAssetAsync<GameObject>(menuEntity.menuAddress.Value).Completed += obj =>
				{
					if (obj.Result == null)
					{
						Debug.LogError("Menu loading failed for " + menuEntity.menuAddress.Value);
						return;
					}
					
					menuEntity.ReplaceMenuPrefab(obj.Result);
					CheckOpenMenus(menuEntity);
				};
			}
		}


		/// <summary>
		/// Close menus if reached the max; then add this one to the list of open menus
		/// </summary>
		/// <param name="menuEntity">represents the menu being loaded</param>
		 private void CheckOpenMenus(MenuEntity menuEntity)
		 {
		 	IUiRegion region = uiContext.GetEntityWithLayerType(menuEntity.layerType.Value).layer.Value.Regions.FirstOrDefault(x => x.Key == menuEntity.regionType.Value).Value;
		    
		    if (!menuEntity.hasView)
		    {
			    if (region == null)
			    {
				    Debug.LogError("Region was not found for entity " + menuEntity.menuType.Value);
				    return;
			    }
			    
			    GameObject newObj = GameObject.Instantiate(menuEntity.menuPrefab.Value, region.MyGameObject.transform);
			    menuEntity.AddView(newObj);

			    IMenuElement menuElement = newObj.GetComponent<IMenuElement>();
			    
			    menuEntity.AddMenu(menuElement);
			    newObj.Link(menuEntity);
			    menuEntity.isLoaded = true;
		    }

		    bool isMenuAlreadyOpen = region.CurrentOpenMenus.Contains(menuEntity);

		    // Close menus in FIFO sorting
		 	int menusToClose = (region.CurrentOpenMenus.Count - region.MaxOpenMenus) + (isMenuAlreadyOpen ? 0 : 1); // should end up with Max-1 still open (or Max if the menu is already open)
		    
		    for (int i = region.CurrentOpenMenus.Count - 1; menusToClose > 0 && i >= 0; i--)
		 	{
			    if (menuEntity != region.CurrentOpenMenus[i])
			    {
				    MenuEntity entity = menuContext.GetEntityWithMenuType(region.CurrentOpenMenus[i].menuType.Value);
				    entity.isLoadMenu = false;
				    region.CurrentOpenMenus.Remove(entity);
				    menusToClose--;
			    }
		 	}
		    
		    if (!isMenuAlreadyOpen)
		    {
			    region.CurrentOpenMenus.Add(menuEntity);
		    }

		    if (region.CurrentOpenMenus.Count > 0 && ! region.MyGameObject.activeSelf)
		    {
			    region.MyGameObject.SetActive(true);
		    }
		 }
	}
}