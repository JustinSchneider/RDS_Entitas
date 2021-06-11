using Sources.UI.Framework.Menus.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Menus
{
    class IngameMenu : MenuElement
    {
        private GameContext gameContext;
        
        [SerializeField] private Button btnResume;
        [SerializeField] private Button btnRestart;
        
        public override void Initialize()
        {
            base.Initialize();
            
            gameContext = Contexts.sharedInstance.game;
            
            btnResume.onClick.AddListener(OnResumeClicked);
            btnRestart.onClick.AddListener(OnRestartClicked);
        }

        private void OnResumeClicked()
        {
            
        }

        private void OnRestartClicked()
        {
            
        }
    }
}