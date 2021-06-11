using Sources.UI.Framework.Menus.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements.Menus
{
    class MainMenu : MenuElement
    {
        private GameContext gameContext;
        
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnQuit;

        public override void Initialize()
        {
            base.Initialize();

            gameContext = Contexts.sharedInstance.game;
            
            btnPlay.onClick.AddListener(OnPlayClicked);
            btnQuit.onClick.AddListener(OnQuitClicked);
        }

        private void OnPlayClicked()
        {
            gameContext.isIsStartNewGame = true;
        }

        private void OnQuitClicked()
        {
            gameContext.isIsQuitGame = true;
        }
    }
}