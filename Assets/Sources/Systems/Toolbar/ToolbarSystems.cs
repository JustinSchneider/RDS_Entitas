using Sources.Systems.Toolbar.Reactive;

namespace Sources.Systems.Toolbar
{
    public class ToolbarSystems : Feature
    {
        public ToolbarSystems(Contexts contexts) : base("Toolbar Systems")
        {
            Add(new LoadToolbarSystem(contexts));
        }
    }
}