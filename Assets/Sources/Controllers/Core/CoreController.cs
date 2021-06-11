using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.VisualDebugging.Unity;
using Sources.Controllers.Core.Interfaces;
using Sources.Services.LoggingService;
using Sources.Services.Interface;
using Sources.Systems.Services;
using Sources.Systems.UI.Framework;
using UnityEngine;
using Sources.BootSequence;
using UnityEngine.SceneManagement;

namespace Sources.Controllers.Core
{
	public class CoreController : MonoBehaviourSingleton<CoreController>, ICoreController
	{
		[SerializeField]
		private Camera mainCamera;

		private readonly Contexts contexts = Contexts.sharedInstance;
		private Entitas.Systems systems;
		private Services.Services services;

		protected override void Awake()
		{
			base.Awake();

			// Don't destroy when reloading scene.
			// TODO:  we may not need this to be tagged as dont destroy
			// a simple reload system which fresh boots everything can call Scene.LoadScene(0);
			//  This would need to go through all of the entitas stuff and remove those Dont destroys
			DontDestroyOnLoad(gameObject);

			//Find shouldnt be used, but just trying to get access
			mainCamera = GameObject.Find(BootSequence.BootSequence.MAIN_CAMERA).GetComponent<Camera>();
		}

		private void InitializeServices()
		{
			BetterStreamingAssets.Initialize();

			//Create our list of services. We should be able to do this from an external file in the future using reflection.
			//The key is the name of the service as it is seen in the services class.
			Dictionary<string, IService> services = new Dictionary<string, IService>();

			services.Add("LogService", new UnityDebugLogService()); //Should be one of the 1st services, as other Services depend on it

			this.services = new Services.Services(services);
		}

		private void InitializeSystems()
		{
			SetupVisualDebugging();

			systems = new Entitas.Systems().Add(new ServicesSystems(this.contexts, this.services))
				.Add(new UiSystems(this.contexts));
		}


		private void SetupVisualDebugging()
		{
		#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
			Transform thisTransform = gameObject.transform;
			
			new ContextObserver(contexts.input).gameObject.transform.SetParent(thisTransform);
			new ContextObserver(contexts.ui).gameObject.transform.SetParent(thisTransform);
			new ContextObserver(contexts.menu).gameObject.transform.SetParent(thisTransform);

			// Alphabetize
			IOrderedEnumerable<Transform> sortedChildren = from child in this.transform.Cast<Transform>() orderby child.name descending select child;
			foreach (Transform child in sortedChildren) child.SetAsFirstSibling();

		#endif //(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
		}

		private void ResetSystems()
		{
			systems.DeactivateReactiveSystems();
			systems.TearDown();
			Contexts.sharedInstance.Reset();
			systems = null;
		}

		private void Start()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;

			InitializeServices();
			InitializeSystems();
			systems.Initialize();
		}

		private void Update()
		{
			systems.Execute();
		}

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			try
			{
				ResetSystems();
				Debug.Log("Reset systems successfully");
			}
			catch (Exception e)
			{
				//No Systems to Reset
				Debug.LogException(e);
			}
		}

		private void OnApplicationQuit()
		{
			ResetSystems();
		}

		private void LateUpdate()
		{
			systems.Cleanup();
		}
	}
}
