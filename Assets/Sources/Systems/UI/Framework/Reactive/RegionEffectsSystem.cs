// using System;
// using System.Collections.Generic;
// using DG.Tweening;
// using Entitas;
// using Sources.Constants;
// using Sources.UI.Framework.Layers;
// using Sources.UI.Utilities;
// using UnityEngine.Rendering.PostProcessing;
//
// namespace Sources.Systems.UI.Framework.Reactive
// {
// 	public class RegionEffectsSystem : ReactiveSystem<UiEntity>
// 	{
// 		private readonly UiContext uiContext;
// 		
// 		public RegionEffectsSystem(Contexts contexts) : base(contexts.ui)
// 		{
// 			this.uiContext = contexts.ui;
// 		}
// 		
// 		protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
// 		{
// 			return context.CreateCollector(UiMatcher.Loaded.AddedOrRemoved());
// 		}
//
// 		protected override bool Filter(UiEntity entity)
// 		{
// 			return entity.hasMenuType && entity.hasRegion && entity.hasLayer;
// 		}
//
// 		protected override void Execute(List<UiEntity> entities)
// 		{
// 			foreach (UiEntity uiEntity in entities)
// 			{
// 				IUiRegion    region = uiContext.uiLayers.Value["Layer " + uiEntity.layer.Value].Regions["Region " + uiEntity.region.Value];
//
// 				if (uiEntity.isLoaded)
// 				{
// 					if (region.CurrentOpenMenus.Count > 0)
// 					{
// 						UiEffects.ApplyEffect(region.RegionEffect);
// 					}
// 				}
// 				else
// 				{
// 					UiEffects.RemoveEffect(region.RegionEffect);
// 				}
// 			}
// 		}
//
//
// 	}
// }