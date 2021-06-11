using Entitas;
using Sources.Systems.UI.Framework.Cleanup;

namespace Sources.Systems.UI.Framework {
	public class UiSystems : Feature
	{
		public UiSystems(Contexts contexts) : base("UI Systems")
		{
			Add(new UiFrameworkSystems(contexts));
			Add(new OpenMenuCleanupSystem(contexts));
		}

		public sealed override Entitas.Systems Add(ISystem system)
		{
			return base.Add(system);
		}
	}
}