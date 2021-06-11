using Entitas;
using Sources.Constants;

namespace Sources.Systems.Services.Initialize
{
    public class RegisterInteractionModeService : IInitializeSystem
    {
        private readonly MetaContext metaContext;

        public RegisterInteractionModeService(Contexts contexts, global::Sources.Services.Services services)
        {
            this.metaContext = contexts.meta;
        }

        public void Initialize()
        {
            this.metaContext.ReplaceInteractionMode(ProjectConstants.InteractionMode.Menu);
        }
    }
}