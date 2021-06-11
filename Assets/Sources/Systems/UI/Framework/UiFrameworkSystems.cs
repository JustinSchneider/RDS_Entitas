using Entitas;
using Sources.Systems.UI.Framework.Initialize;
using Sources.Systems.UI.Framework.Reactive;

namespace Sources.Systems.UI.Framework {
	public class UiFrameworkSystems : Feature
	{
		public UiFrameworkSystems(Contexts contexts) : base("Initialize UI Systems")
		{
			Add(new InitializeUiRoot(contexts));

			Add(new InitializeUiLayersSystem(contexts));
			Add(new InitializeMenusSystem(contexts));
			Add(new MenuLoadSystem(contexts));
			Add(new MenuUnloadSystem(contexts));
			
			// Add(new RegionEffectsSystem(contexts));
			// Add(new ChangeCurrentTabbedMenuSystem(contexts));
		}

		public sealed override Entitas.Systems Add(ISystem system)
		{
			return base.Add(system);
		}
	}
}