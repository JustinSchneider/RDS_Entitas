using System.Collections.Generic;
using Entitas;
using Sources.Constants;

namespace Sources.Systems.Toolbar.Reactive
{
    public class LoadToolbarSystem : ReactiveSystem<GameEntity>
    {
        private readonly MenuContext menuContext;
        private readonly GameContext gameContext;
        
        public LoadToolbarSystem(Contexts contexts) : base(contexts.game)
        {
            menuContext = contexts.menu;
            gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.StartNewGame);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            menuContext.GetEntityWithMenuType(UIConstants.Menu.MainMenu).isLoadMenu = false;
            menuContext.GetEntityWithMenuType(UIConstants.Menu.ToolbarMenu).isLoadMenu = true;
        }
    }
}