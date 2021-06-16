using Sources.UI.Framework.Menus.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Menus
{
    class ToolbarMenu : MenuElement
    {
        private CubeContext cubeContext;
        
        [SerializeField] private Button btnSpawn;
        public override void Initialize()
        {
            base.Initialize();

            cubeContext = Contexts.sharedInstance.cube;

            btnSpawn.onClick.AddListener(OnSpawnClicked);
        }

        private void OnSpawnClicked()
        {
            var newCube = cubeContext.CreateEntity();
            newCube.isToSpawn = true;
        }
    }
}