using System.Collections.Generic;
using Entitas;
using Sources.Constants;
using Sources.UI.Framework.Layers;

namespace Sources.Systems.UI.Framework.Reactive
{
	public class InitializeUiLayersSystem : ReactiveSystem<UiEntity>
	{
		private readonly UiContext uiContext;
		
		public InitializeUiLayersSystem(Contexts contexts) : base(contexts.ui)
		{
			this.uiContext = contexts.ui;
		}
		
		protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
		{
			return context.CreateCollector(UiMatcher.UiRoot.Added());
		}

		protected override bool Filter(UiEntity entity)
		{
			return entity.hasUiRoot;
		}

		protected override void Execute(List<UiEntity> entities)
		{
			IUiLayer[] uiLayers = uiContext.uiRoot.Value.GetComponentsInChildren<IUiLayer>();

			foreach (IUiLayer uiLayer in uiLayers)
			{
				UiEntity layerEntity = uiContext.CreateEntity();
				layerEntity.AddLayerType(uiLayer.Type);
				layerEntity.AddLayer(uiLayer);

				uiLayer.Initialize();
			}

			uiContext.CreateEntity().isInitialize = true;
		}
	}
}