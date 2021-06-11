using Entitas;

namespace Sources.Systems.UI.Framework.Cleanup {
	public class OpenMenuCleanupSystem : ICleanupSystem
	{
		private readonly UiContext uiContext;

		public OpenMenuCleanupSystem(Contexts contexts)
		{
			uiContext = contexts.ui;
		}

		public void Cleanup()
		{
			foreach (UiEntity uiEntity in uiContext.GetGroup(UiMatcher.OpenMenu).GetEntities())
			{
				uiEntity.Destroy();
			}
		}
	}
}