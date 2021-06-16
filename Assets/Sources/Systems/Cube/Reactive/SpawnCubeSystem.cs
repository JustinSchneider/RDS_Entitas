using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Sources.Constants;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sources.Systems.Cube.Reactive
{
    public class SpawnCubeSystem : ReactiveSystem<CubeEntity>
    {
        private readonly CubeContext cubeContext;
        private readonly Camera mainCamera;
        
        // The maximum number of locations the spawner will attempt to spawn in before giving up and allowing
        // the new cube to overlap an old one
        private const int MaxSpawnAttempts = 50;
        
        public SpawnCubeSystem(Contexts contexts) : base(contexts.cube)
        {
            cubeContext = contexts.cube;
            mainCamera = contexts.meta.mainCameraGameObject.Value.GetComponent<Camera>();
        }

        protected override ICollector<CubeEntity> GetTrigger(IContext<CubeEntity> context)
        {
            return context.CreateCollector(CubeMatcher.ToSpawn);
        }

        protected override bool Filter(CubeEntity entity) => true;

        protected override void Execute(List<CubeEntity> entities)
        {
            //Prepare excess cubes for despawning
            var spawnedCubes = cubeContext.GetEntities();

            if (spawnedCubes.Length >= CubeConstants.MaxCubes)
            {
                for (int i = 0; i < spawnedCubes.Length - CubeConstants.MaxCubes; i++)
                {
                    spawnedCubes[i].isToSpawn = false;
                }
            }
            
            foreach (var cubeEntity in entities)
            {
                cubeEntity.ReplacePosition(GenerateSpawnPosition());
                cubeEntity.ReplaceAssetAddress(CubeConstants.CubePrefabAddress);
                LoadView(cubeEntity);
            }
        }

        protected Vector3 GenerateSpawnPosition()
        {
            Vector3 result;
            int attempts = 0;
            // Attempts to find a spawn position that does not overlap any other cubes
            do
            {
                //Get a rondom position in Viewport space
                result = new Vector3(Random.value, Random.value, Random.value);
                result.z *= CubeConstants.MaxSpawnDistance;
                
                // push the cube back to ensure it does not overlap the camera
                result.z += CubeConstants.CubePrefabHalfExtents + mainCamera.nearClipPlane;
                result = mainCamera.ViewportToWorldPoint(result);
                attempts++;
                
                // If we hit the max attempts, just give up and allow an overlap
                if (attempts > MaxSpawnAttempts)
                {
                    Debug.LogWarning("Maximum number of positions checked for spawning, consider reducing the prefab size");
                    break;
                }

            } while (Physics.CheckBox(result, Vector3.one * CubeConstants.CubePrefabHalfExtents, 
                     Quaternion.identity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore));
            
            return result;
        }

        protected void LoadView(CubeEntity cubeEntity)
        {
            if (cubeEntity.hasView)
            {
                cubeEntity.view.Value.SetActive(true);
                return;
            }
            
            Addressables.LoadAssetAsync<GameObject>(cubeEntity.assetAddress.Value).Completed += obj =>
            {
                if (obj.Result == null)
                {
                    Debug.LogError("Failed to load Asset at address" + cubeEntity.assetAddress.Value);
                    return;
                }

                var newObj = GameObject.Instantiate(obj.Result, cubeEntity.position.Value, Quaternion.identity);
                cubeEntity.ReplaceView(newObj);
                newObj.Link(cubeEntity);
            };
        }
    }
}