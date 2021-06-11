using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.UI.Framework.Base
{
	abstract class UiElement : SerializedMonoBehaviour, IUiElement
	{
		[Tooltip("When OnDisable fires should the gameobject be disabled?")]
		[SerializeField] private bool DisableOnDisable = false;
		
		public virtual string     Id         { get; protected set; }
		public         GameObject GameObject { get; private set; }
		public virtual bool       Enabled    { get; protected set; }
		
		private bool Initialized { get; set; }

		public virtual void SetInteractable(bool state)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Initialize()
		{
			GameObject obj = gameObject;
			
			Id         = Id ?? obj.name; // Used in case a developer called SetId before initialize;
			GameObject = obj;
			Enabled    = enabled;

			Initialized = true;
		}

		public void SetId(string newId)
		{
			Id = newId;
		}

		public virtual void OnEnable()
		{
			if(!Initialized) Initialize();
			
			Enabled = true;
			gameObject.SetActive(true);
		}

		public virtual void OnDisable()
		{
			Enabled = false;
			
			if(DisableOnDisable)
				gameObject.SetActive(false);
		}
	}
}