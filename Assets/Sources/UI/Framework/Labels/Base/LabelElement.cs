using Sources.UI.Framework.Base;
using Sources.UI.Framework.Labels.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Framework.Labels.Base
{
	abstract class LabelElement : UiElement, ILabelElement
	{
		protected TMP_Text unityText;

		public TMP_Text UnityText => unityText;

		public override void Initialize()
		{
			base.Initialize();
			unityText = GetComponent<TMP_Text>();
		}
	}
}