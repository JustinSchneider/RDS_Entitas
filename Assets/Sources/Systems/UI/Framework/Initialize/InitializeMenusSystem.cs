using System.Collections.Generic;
using Entitas;
using Sources.Constants;
using Sources.UI.Framework.Menus.Base;

namespace Sources.Systems.UI.Framework.Initialize
{
	public class InitializeMenusSystem : ReactiveSystem<UiEntity>
	{
		private readonly MenuContext menuContext;
		
		public InitializeMenusSystem(Contexts contexts) : base(contexts.ui)
		{
			this.menuContext = contexts.menu;
		}
		
		protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
		{
			return context.CreateCollector(UiMatcher.Initialize.Added());
		}

		protected override bool Filter(UiEntity entity)
		{
			return entity.isInitialize;
		}

		protected override void Execute(List<UiEntity> entities)
		{
			foreach (UiEntity uiEntity in entities)
			{
				foreach (KeyValuePair<UIConstants.Menu, MenuConfig> menu in UIConstants.MenuAddresses)
				{
					MenuConfig config    = menu.Value;
					MenuEntity   newEntity = menuContext.CreateEntity();
					newEntity.AddMenuType(menu.Key);
					newEntity.AddLayerType(config.Layer);
					newEntity.AddRegionType(config.Region);
					newEntity.AddLoadMode(config.LoadMode);
					newEntity.AddMenuAddress(config.Address);

					if (menu.Value.LoadAtStart) newEntity.isLoadMenu = true;
				}
			}
		}
	}
}