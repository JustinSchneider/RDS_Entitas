using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Sources.BootSequence
{
	public class BootSequence : MonoBehaviourSingleton<BootSequence>
	{
		private bool verbose = false;

		public static string MAIN_CAMERA = "Main Camera";
		public static string DIRECTIONAL_LIGHT = "Directional Light";
		public static string EVENT_SYSTEM = "EventSystem";
		public static string OBJECT_POOLS = "ObjectPools";
		public static string CORE_CONTROLLER = "Core Controller";

		//addressables location paths
		private const string MAIN_CAMERA_PATH = "Assets/Prefabs/BootItems/MainCamera.prefab";
		private const string DIRECTIONAL_LIGHT_PATH = "Assets/Prefabs/BootItems/DirectionalLight.prefab";
		private const string EVENT_SYSTEM_PATH = "Assets/Prefabs/BootItems/EventSystem.prefab";
		private const string OBJECT_POOL_PATH = "Assets/Prefabs/BootItems/ObjectPools.prefab";
		private const string CORE_CONTROLLER_PATH = "Assets/Prefabs/BootItems/CoreController.prefab";

		protected override void Awake()
		{
			base.Awake();
			AddLoadingScene();
		}

		private void AddLoadingScene()
		{
			//SceneManager.LoadScene(1, LoadSceneMode.Additive);
			createBootItems();
		}

		/// <summary>
		/// createBootItems
		/// dynamically load our objects at boot
		/// </summary>
		private void createBootItems()
		{
			Addressables.InstantiateAsync(MAIN_CAMERA_PATH).Completed += handleMainCameraCreated;
		}

		private void handleMainCameraCreated(AsyncOperationHandle<GameObject> mainCamera)
		{
			mainCamera.Result.gameObject.name = MAIN_CAMERA;
			Addressables.InstantiateAsync(DIRECTIONAL_LIGHT_PATH).Completed += handleDirectionalLightCreated;
		}

		private void handleDirectionalLightCreated(AsyncOperationHandle<GameObject> dirLight)
		{
			dirLight.Result.gameObject.name = DIRECTIONAL_LIGHT;
			Addressables.InstantiateAsync(EVENT_SYSTEM_PATH).Completed += handleEventsSystemCreated;
		}

		private void handleEventsSystemCreated(AsyncOperationHandle<GameObject> eventSystem)
		{
			eventSystem.Result.gameObject.name = EVENT_SYSTEM;
			Addressables.InstantiateAsync(OBJECT_POOL_PATH).Completed += handleObjectPoolCreated;
		}

		private void handleObjectPoolCreated(AsyncOperationHandle<GameObject> objectPool)
		{
			objectPool.Result.gameObject.name = OBJECT_POOLS;
			Addressables.InstantiateAsync(CORE_CONTROLLER_PATH).Completed += handleCoreControllerCreated;
		}

		private void handleCoreControllerCreated(AsyncOperationHandle<GameObject> coreController)
		{
			coreController.Result.gameObject.name = CORE_CONTROLLER;
			if(verbose) Debug.LogWarning("CoreController created - boot items complete");
		}
	}
}
