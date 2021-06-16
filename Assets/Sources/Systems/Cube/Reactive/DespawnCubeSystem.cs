using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Systems.Cube.Reactive
{
    public class DespawnCubeSystem : ReactiveSystem<CubeEntity>
    {
        public DespawnCubeSystem(Contexts contexts) : base(contexts.cube) { }

        protected override ICollector<CubeEntity> GetTrigger(IContext<CubeEntity> context)
        {
            return context.CreateCollector(CubeMatcher.ToSpawn.Removed());
        }

        protected override bool Filter(CubeEntity entity) => !entity.isToSpawn;

        protected override void Execute(List<CubeEntity> entities)
        {
            foreach (var cubeEntity in entities)
            {
                Object.Destroy(cubeEntity.view.Value);
                cubeEntity.view.Value.Unlink();
                cubeEntity.RemoveAllComponents();
            }
        }
    }
}