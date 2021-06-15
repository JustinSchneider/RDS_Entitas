using System.Collections.Generic;
using Sources.UI.Framework.Menus.Base;

namespace Sources.Constants
{
    public static class UIConstants
    {
        public const string UiRootPath = "Assets/Prefabs/UI/UIRoot.prefab";

        public enum LoadMode
        {
            Unload,
            DontUnload
        }
        public enum Menu
        {
            MainMenu,
            InGameMenu
        }
        
        public enum Layer
        {
            Base,
            Popup
        }

        public enum Region
        {
            Default
        }
        
        public static readonly Dictionary<Menu, MenuConfig> MenuAddresses = new Dictionary<Menu, MenuConfig>
        {
            {
                Menu.MainMenu,
                new MenuConfig("Assets/Prefabs/UI/Menus/MainMenu.prefab", Layer.Base, Region.Default, LoadMode.Unload,true)
            },
            {
                Menu.InGameMenu,
                new MenuConfig("Assets/Prefabs/UI/Menus/IngameMenu.prefab", Layer.Popup, Region.Default, LoadMode.Unload,false)
            }
        };
    }
}