using Sources.Constants;

namespace Sources.UI.Framework.Menus.Base {
	public struct MenuConfig
	{
		public string Address { get; }
		public UIConstants.Layer Layer { get; }
		public UIConstants.Region Region { get; }
		public UIConstants.LoadMode LoadMode { get; }
		public bool LoadAtStart { get; }

		public MenuConfig(string _address, UIConstants.Layer _layer, UIConstants.Region _region, UIConstants.LoadMode _loadMode, bool _loadAtStart)
		{
			Address = _address;
			Layer = _layer;
			Region = _region;
			LoadMode = _loadMode;
			LoadAtStart = _loadAtStart;
		}
	}
}