using Sources.Systems.Cube.Reactive;

namespace Sources.Systems.Cube
{
    public class CubeSystems : Feature
    {
        public CubeSystems(Contexts contexts) : base("Cube Systems")
        {
            Add(new SpawnCubeSystem(contexts));
            Add(new DespawnCubeSystem(contexts));
        }
    }
}