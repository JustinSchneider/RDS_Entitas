using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sources.UI.Framework.Layers;
using Sources.UI.Framework.Menus.Base;
using UnityEditor;
using UnityEngine;

namespace Sources.Constants
{
	public static class ProjectConstants
	{
		public static int defaultMaxFPS = 60;

		public const string WebServiceHeaderName = "content-type";
		public const string WebServiceHeaderValue = "application/json; charset=utf-8";
		
		// ENTITY HELPER SERVICE
		public const string GETENTITYWITHUUIDMETHODNAME = "GetEntityWithuuid";
		public const string GETENTITYWITHGUIDMETHODNAME = "GetEntityWithGuid";

		public struct ColorConst{
			public static Color32 logoColor = new Color32(0, 200, 0, 255);
		}

		public enum InteractionMode
		{
			None,
			Menu,
			Gameplay
		}
	}
}